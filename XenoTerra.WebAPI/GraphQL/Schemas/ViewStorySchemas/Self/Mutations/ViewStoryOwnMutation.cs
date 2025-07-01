using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions.Events;
using XenoTerra.BussinessLogicLayer.Services.Entity.ViewStoryServices.Read;
using XenoTerra.BussinessLogicLayer.Services.Entity.ViewStoryServices.Write.Own;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Self.Own;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.ViewStoryMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class ViewStoryOwnMutation
    {
        public async Task<CreateViewStoryOwnPayload> CreateOwnViewStoryAsync(
            [Service] IViewStoryOwnMutationService mutationService,
            [Service] IViewStoryOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateViewStoryOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateViewStoryOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateViewStoryOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateViewStoryOwnInput, CreateViewStoryOwnDto>(input);
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateViewStoryOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendViewStoryEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateViewStoryOwnPayload> UpdateOwnViewStoryAsync(
            [Service] IViewStoryOwnMutationService mutationService,
            [Service] IViewStoryOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateViewStoryOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateViewStoryOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateViewStoryOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateViewStoryOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateViewStoryOwnInput, UpdateViewStoryOwnDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var payload = await mutationService.UpdateAsync<UpdateViewStoryOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendViewStoryEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteViewStoryOwnPayload> DeleteOwnViewStoryAsync(
            [Service] IViewStoryOwnMutationService mutationService,
            [Service] IViewStoryReadService readService,
            [Service] IViewStoryOwnWriteService writeService,
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

            var payload = await mutationService.DeleteAsync<DeleteViewStoryOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendViewStoryEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendViewStoryEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultViewStoryOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(ViewStoryOwnSubscription.OnViewStoryOwnCreated),
                        ViewStoryOwnCreatedEvent.From<ViewStoryOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ViewStoryOwnSubscription.OnViewStoryOwnUpdated),
                        ViewStoryOwnUpdatedEvent.From<ViewStoryOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ViewStoryOwnSubscription.OnViewStoryOwnDeleted),
                        ViewStoryOwnDeletedEvent.From<ViewStoryOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ViewStoryOwnSubscription.OnViewStoryOwnChanged),
                ViewStoryOwnChangedEvent.From<ViewStoryOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

