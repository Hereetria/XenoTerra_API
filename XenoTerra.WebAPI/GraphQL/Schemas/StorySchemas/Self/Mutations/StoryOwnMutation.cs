using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Own.StoryMutationServices;
using XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions.Events;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryServices.Read;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class StoryOwnMutation
    {
        public async Task<CreateStoryOwnPayload> CreateOwnStoryAsync(
            [Service] IStoryOwnMutationService mutationService,
            [Service] IStoryOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateStoryOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateStoryOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateStoryOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateStoryOwnInput, CreateStoryOwnDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateStoryOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendStoryEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateStoryOwnPayload> UpdateOwnStoryAsync(
            [Service] IStoryOwnMutationService mutationService,
            [Service] IStoryOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateStoryOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateStoryOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateStoryOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateStoryOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateStoryOwnInput, UpdateStoryOwnDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateStoryOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendStoryEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteStoryOwnPayload> DeleteOwnStoryAsync(
            [Service] IStoryOwnMutationService mutationService,
            [Service] IStoryReadService readService,
            [Service] IStoryOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var story = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.UserId
            );

            if (story.UserId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteStoryOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendStoryEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendStoryEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultStoryOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(StoryOwnSubscription.OnStoryOwnCreated),
                        StoryOwnCreatedEvent.From<StoryOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(StoryOwnSubscription.OnStoryOwnUpdated),
                        StoryOwnUpdatedEvent.From<StoryOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(StoryOwnSubscription.OnStoryOwnDeleted),
                        StoryOwnDeletedEvent.From<StoryOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(StoryOwnSubscription.OnStoryOwnChanged),
                StoryOwnChangedEvent.From<StoryOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

