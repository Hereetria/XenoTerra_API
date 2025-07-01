using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Mutations.Inputs;
using XenoTerra.BussinessLogicLayer.Services.Entity.RecentChatsServices.Write.Own;
using XenoTerra.BussinessLogicLayer.Services.Entity.RecentChatsServices.Read;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Self.Own;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.RecentChatsMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class RecentChatsOwnMutation
    {
        public async Task<CreateRecentChatsOwnPayload> CreateOwnRecentChatsAsync(
            [Service] IRecentChatsOwnMutationService mutationService,
            [Service] IRecentChatsOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateRecentChatsOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateRecentChatsOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateRecentChatsOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateRecentChatsOwnInput, CreateRecentChatsOwnDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateRecentChatsOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendRecentChatsEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateRecentChatsOwnPayload> UpdateOwnRecentChatsAsync(
            [Service] IRecentChatsOwnMutationService mutationService,
            [Service] IRecentChatsOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateRecentChatsOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateRecentChatsOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateRecentChatsOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateRecentChatsOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateRecentChatsOwnInput, UpdateRecentChatsOwnDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var payload = await mutationService.UpdateAsync<UpdateRecentChatsOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendRecentChatsEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteRecentChatsOwnPayload> DeleteOwnRecentChatsAsync(
            [Service] IRecentChatsOwnMutationService mutationService,
            [Service] IRecentChatsReadService readService,
            [Service] IRecentChatsOwnWriteService writeService,
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

            var payload = await mutationService.DeleteAsync<DeleteRecentChatsOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendRecentChatsEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendRecentChatsEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultRecentChatsOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(RecentChatsOwnSubscription.OnRecentChatsOwnCreated),
                        RecentChatsOwnCreatedEvent.From<RecentChatsOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(RecentChatsOwnSubscription.OnRecentChatsOwnUpdated),
                        RecentChatsOwnUpdatedEvent.From<RecentChatsOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(RecentChatsOwnSubscription.OnRecentChatsOwnDeleted),
                        RecentChatsOwnDeletedEvent.From<RecentChatsOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(RecentChatsOwnSubscription.OnRecentChatsOwnChanged),
                RecentChatsOwnChangedEvent.From<RecentChatsOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

