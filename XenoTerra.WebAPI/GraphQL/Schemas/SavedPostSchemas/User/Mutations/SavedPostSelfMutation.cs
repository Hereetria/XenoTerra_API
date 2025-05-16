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
    public class SavedPostSelfMutation
    {
        public async Task<CreateSavedPostSelfPayload> CreateSavedPostAsync(
            [Service] ISavedPostMutationService mutationService,
            [Service] ISavedPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreateSavedPostSelfInput> inputSelfValidator,
            CreateSavedPostSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateSavedPostSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateSavedPostSelfInput, CreateSavedPostDto>(input);
            var payload = await mutationService.CreateAsync<CreateSavedPostSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendSavedPostEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateSavedPostSelfPayload> UpdateSavedPostAsync(
            [Service] ISavedPostMutationService mutationService,
            [Service] ISavedPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateSavedPostSelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateSavedPostSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateSavedPostSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateSavedPostSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateSavedPostSelfInput, UpdateSavedPostDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateSavedPostSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendSavedPostEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteSavedPostSelfPayload> DeleteSavedPostAsync(
            [Service] ISavedPostMutationService mutationService,
            [Service] ISavedPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteSavedPostSelfPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(SavedPostSelfSubscription.OnSavedPostCreated),
                        SavedPostCreatedSelfEvent.From<SavedPostCreatedSelfEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(SavedPostSelfSubscription.OnSavedPostUpdated),
                        SavedPostUpdatedSelfEvent.From<SavedPostUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(SavedPostSelfSubscription.OnSavedPostDeleted),
                        SavedPostDeletedSelfEvent.From<SavedPostDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(SavedPostSelfSubscription.OnSavedPostChanged),
                SavedPostChangedSelfEvent.From<SavedPostChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
