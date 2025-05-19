using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.ViewStoryServices;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.ViewStoryMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class ViewStorySelfMutation
    {
        public async Task<CreateViewStorySelfPayload> CreateMyViewStoryAsync(
            [Service] IViewStorySelfMutationService mutationService,
            [Service] IViewStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateViewStorySelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateViewStorySelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateViewStorySelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateViewStorySelfInput, CreateViewStoryDto>(input);
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateViewStorySelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendViewStoryEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateViewStorySelfPayload> UpdateMyViewStoryAsync(
            [Service] IViewStorySelfMutationService mutationService,
            [Service] IViewStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateViewStorySelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateViewStorySelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateViewStorySelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateViewStorySelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateViewStorySelfInput, UpdateViewStoryDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateViewStorySelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendViewStoryEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteViewStorySelfPayload> DeleteMyViewStoryAsync(
            [Service] IViewStorySelfMutationService mutationService,
            [Service] IViewStoryReadService readService,
            [Service] IViewStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var viewStory = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.UserId
            );

            if (viewStory.UserId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteViewStorySelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendViewStoryEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendViewStoryEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultViewStoryDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(ViewStorySelfSubscription.OnViewStorySelfCreated),
                        ViewStorySelfCreatedEvent.From<ViewStorySelfCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ViewStorySelfSubscription.OnViewStorySelfUpdated),
                        ViewStorySelfUpdatedEvent.From<ViewStorySelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ViewStorySelfSubscription.OnViewStorySelfDeleted),
                        ViewStorySelfDeletedEvent.From<ViewStorySelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ViewStorySelfSubscription.OnViewStorySelfChanged),
                ViewStorySelfChangedEvent.From<ViewStorySelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

