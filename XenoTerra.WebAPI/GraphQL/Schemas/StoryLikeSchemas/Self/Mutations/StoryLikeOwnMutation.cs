using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Own.StoryLikeOwnMutationServices;
using XenoTerra.DTOLayer.Dtos.StoryLikeAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Mutations.Payloads;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryLikeServices.Write.Own;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryLikeServices.Read;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class StoryLikeOwnMutation
    {
        public async Task<CreateStoryLikeOwnPayload> CreateMyLikeAsync(
            [Service] IStoryLikeOwnMutationService mutationService,
            [Service] IStoryLikeOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateStoryLikeOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateStoryLikeOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateStoryLikeOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateStoryLikeOwnInput, CreateStoryLikeOwnDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateStoryLikeOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateStoryLikeOwnPayload> UpdateMyLikeAsync(
            [Service] IStoryLikeOwnMutationService mutationService,
            [Service] IStoryLikeOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateStoryLikeOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateStoryLikeOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateStoryLikeOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateStoryLikeOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateStoryLikeOwnInput, UpdateStoryLikeOwnDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateStoryLikeOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteStoryLikeOwnPayload> DeleteMyLikeAsync(
            [Service] IStoryLikeOwnMutationService mutationService,
            [Service] IStoryLikeReadService readService,
            [Service] IStoryLikeOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var like = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.UserId
            );

            if (like.UserId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteStoryLikeOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }

        private async Task SendLikeEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultStoryLikeOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(StoryLikeOwnSubscription.OnLikeOwnCreated),
                        StoryLikeOwnCreatedEvent.From<StoryLikeOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(StoryLikeOwnSubscription.OnLikeOwnUpdated),
                        StoryLikeOwnUpdatedEvent.From<StoryLikeOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(StoryLikeOwnSubscription.OnLikeOwnDeleted),
                        StoryLikeOwnDeletedEvent.From<StoryLikeOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(StoryLikeOwnSubscription.OnLikeOwnChanged),
                StoryLikeOwnChangedEvent.From<StoryLikeOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

