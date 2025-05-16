using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryService;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.StoryMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations
{
    public class StoryAdminMutation
    {
        public async Task<CreateStoryAdminPayload> CreateStoryAsync(
            [Service] IStoryMutationService mutationService,
            [Service] IStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<CreateStoryAdminInput> inputAdminValidator,
            CreateStoryAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateStoryAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateStoryAdminInput, CreateStoryDto>(input);
            var payload = await mutationService.CreateAsync<CreateStoryAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendStoryEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateStoryAdminPayload> UpdateStoryAsync(
            [Service] IStoryMutationService mutationService,
            [Service] IStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<UpdateStoryAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateStoryAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateStoryAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateStoryAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateStoryAdminInput, UpdateStoryDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateStoryAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendStoryEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteStoryAdminPayload> DeleteStoryAsync(
            [Service] IStoryMutationService mutationService,
            [Service] IStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var payload = await mutationService.DeleteAsync<DeleteStoryAdminPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendStoryEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendStoryEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultStoryDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(StoryAdminSubscription.OnStoryCreated),
                        StoryCreatedAdminEvent.From<StoryCreatedAdminEvent>(result, userId, now));
                    break;
                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(StoryAdminSubscription.OnStoryUpdated),
                        StoryUpdatedAdminEvent.From<StoryUpdatedAdminEvent>(result, userId, now, modifiedFields ?? []));
                    break;
                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(StoryAdminSubscription.OnStoryDeleted),
                        StoryDeletedAdminEvent.From<StoryDeletedAdminEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(StoryAdminSubscription.OnStoryChanged),
                StoryChangedAdminEvent.From<StoryChangedAdminEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
