using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.ViewStoryService;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.ViewStoryMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Mutations
{
    public class ViewStoryAdminMutation
    {
        public async Task<CreateViewStoryAdminPayload> CreateViewStoryAsync(
            [Service] IViewStoryMutationService mutationService,
            [Service] IViewStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<CreateViewStoryAdminInput> inputAdminValidator,
            CreateViewStoryAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateViewStoryAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateViewStoryAdminInput, CreateViewStoryDto>(input);
            var payload = await mutationService.CreateAsync<CreateViewStoryAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendViewStoryEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateViewStoryAdminPayload> UpdateViewStoryAsync(
            [Service] IViewStoryMutationService mutationService,
            [Service] IViewStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<UpdateViewStoryAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateViewStoryAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateViewStoryAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateViewStoryAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateViewStoryAdminInput, UpdateViewStoryDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateViewStoryAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendViewStoryEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteViewStoryAdminPayload> DeleteViewStoryAsync(
            [Service] IViewStoryMutationService mutationService,
            [Service] IViewStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteViewStoryAdminPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendViewStoryEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendViewStoryEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultViewStoryDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(ViewStoryAdminSubscription.OnViewStoryCreated),
                        ViewStoryCreatedAdminEvent.From<ViewStoryCreatedAdminEvent>(result, userId, now));
                    break;
                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ViewStoryAdminSubscription.OnViewStoryUpdated),
                        ViewStoryUpdatedAdminEvent.From<ViewStoryUpdatedAdminEvent>(result, userId, now, modifiedFields ?? []));
                    break;
                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ViewStoryAdminSubscription.OnViewStoryDeleted),
                        ViewStoryDeletedAdminEvent.From<ViewStoryDeletedAdminEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ViewStoryAdminSubscription.OnViewStoryChanged),
                ViewStoryChangedAdminEvent.From<ViewStoryChangedAdminEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
