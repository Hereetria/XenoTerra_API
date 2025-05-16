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
    public class SavedPostAdminMutation
    {
        public async Task<CreateSavedPostAdminPayload> CreateSavedPostAsync(
            [Service] ISavedPostMutationService mutationService,
            [Service] ISavedPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<CreateSavedPostAdminInput> inputAdminValidator,
            CreateSavedPostAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateSavedPostAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateSavedPostAdminInput, CreateSavedPostDto>(input);
            var payload = await mutationService.CreateAsync<CreateSavedPostAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendSavedPostEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateSavedPostAdminPayload> UpdateSavedPostAsync(
            [Service] ISavedPostMutationService mutationService,
            [Service] ISavedPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<UpdateSavedPostAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateSavedPostAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateSavedPostAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateSavedPostAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateSavedPostAdminInput, UpdateSavedPostDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateSavedPostAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendSavedPostEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteSavedPostAdminPayload> DeleteSavedPostAsync(
            [Service] ISavedPostMutationService mutationService,
            [Service] ISavedPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteSavedPostAdminPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(SavedPostAdminSubscription.OnSavedPostCreated),
                        SavedPostCreatedAdminEvent.From<SavedPostCreatedAdminEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(SavedPostAdminSubscription.OnSavedPostUpdated),
                        SavedPostUpdatedAdminEvent.From<SavedPostUpdatedAdminEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(SavedPostAdminSubscription.OnSavedPostDeleted),
                        SavedPostDeletedAdminEvent.From<SavedPostDeletedAdminEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(SavedPostAdminSubscription.OnSavedPostChanged),
                SavedPostChangedAdminEvent.From<SavedPostChangedAdminEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
