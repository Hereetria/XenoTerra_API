using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.RecentChatsServices;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.RecentChatsMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class RecentChatsSelfMutation
    {
        public async Task<CreateRecentChatsSelfPayload> CreateMyRecentChatsAsync(
            [Service] IRecentChatsSelfMutationService mutationService,
            [Service] IRecentChatsWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateRecentChatsSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateRecentChatsSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateRecentChatsSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateRecentChatsSelfInput, CreateRecentChatsDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateRecentChatsSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendRecentChatsEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateRecentChatsSelfPayload> UpdateMyRecentChatsAsync(
            [Service] IRecentChatsSelfMutationService mutationService,
            [Service] IRecentChatsWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateRecentChatsSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateRecentChatsSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateRecentChatsSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateRecentChatsSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateRecentChatsSelfInput, UpdateRecentChatsDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateRecentChatsSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendRecentChatsEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteRecentChatsSelfPayload> DeleteMyRecentChatsAsync(
            [Service] IRecentChatsSelfMutationService mutationService,
            [Service] IRecentChatsReadService readService,
            [Service] IRecentChatsWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var recentChats = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.UserId
            );

            if (recentChats.UserId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteRecentChatsSelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendRecentChatsEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendRecentChatsEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultRecentChatsDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(RecentChatsSelfSubscription.OnRecentChatsSelfCreated),
                        RecentChatsSelfCreatedEvent.From<RecentChatsSelfCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(RecentChatsSelfSubscription.OnRecentChatsSelfUpdated),
                        RecentChatsSelfUpdatedEvent.From<RecentChatsSelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(RecentChatsSelfSubscription.OnRecentChatsSelfDeleted),
                        RecentChatsSelfDeletedEvent.From<RecentChatsSelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(RecentChatsSelfSubscription.OnRecentChatsSelfChanged),
                RecentChatsSelfChangedEvent.From<RecentChatsSelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

