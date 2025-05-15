using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.SavedPostService;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.SavedPostMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Mutations
{
    public class SavedPostMutation
    {
        public async Task<CreateSavedPostPayload> CreateSavedPostAsync(
            [Service] ISavedPostMutationService mutationService,
            [Service] ISavedPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateSavedPostInput> inputValidator,
            CreateSavedPostInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateSavedPostInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateSavedPostInput, CreateSavedPostDto>(input);
            var payload = await mutationService.CreateAsync<CreateSavedPostPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendSavedPostEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateSavedPostPayload> UpdateSavedPostAsync(
            [Service] ISavedPostMutationService mutationService,
            [Service] ISavedPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateSavedPostInput> inputValidator,
            IResolverContext context,
            UpdateSavedPostInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateSavedPostInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateSavedPostInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateSavedPostInput, UpdateSavedPostDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateSavedPostPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendSavedPostEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteSavedPostPayload> DeleteSavedPostAsync(
            [Service] ISavedPostMutationService mutationService,
            [Service] ISavedPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteSavedPostPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendSavedPostEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendSavedPostEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultSavedPostDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(SavedPostSubscription.OnSavedPostCreated),
                        SavedPostCreatedEvent.From<SavedPostCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(SavedPostSubscription.OnSavedPostUpdated),
                        SavedPostUpdatedEvent.From<SavedPostUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(SavedPostSubscription.OnSavedPostDeleted),
                        SavedPostDeletedEvent.From<SavedPostDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(SavedPostSubscription.OnSavedPostChanged),
                SavedPostChangedEvent.From<SavedPostChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
