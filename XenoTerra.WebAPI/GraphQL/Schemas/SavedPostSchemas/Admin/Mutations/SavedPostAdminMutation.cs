using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.SavedPostMutationServices;
using XenoTerra.DTOLayer.Dtos.SavedPostAdminDtos.Admin;
using XenoTerra.BussinessLogicLayer.Services.Entity.SavedPostServices.Write.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class SavedPostAdminMutation
    {
        public async Task<CreateSavedPostAdminPayload> CreateSavedPostAsync(
            [Service] ISavedPostAdminMutationService mutationService,
            [Service] ISavedPostAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateSavedPostAdminInput> inputAdminValidator,
            CreateSavedPostAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateSavedPostAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateSavedPostAdminInput, CreateSavedPostAdminDto>(input);
            var payload = await mutationService.CreateAsync<CreateSavedPostAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendSavedPostEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateSavedPostAdminPayload> UpdateSavedPostAsync(
            [Service] ISavedPostAdminMutationService mutationService,
            [Service] ISavedPostAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateSavedPostAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateSavedPostAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateSavedPostAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateSavedPostAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateSavedPostAdminInput, UpdateSavedPostAdminDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateSavedPostAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendSavedPostEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteSavedPostAdminPayload> DeleteSavedPostAsync(
            [Service] ISavedPostAdminMutationService mutationService,
            [Service] ISavedPostAdminWriteService writeService,
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
            ResultSavedPostAdminDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(SavedPostAdminSubscription.OnSavedPostAdminCreated),
                        SavedPostAdminCreatedEvent.From<SavedPostAdminCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(SavedPostAdminSubscription.OnSavedPostAdminUpdated),
                        SavedPostAdminUpdatedEvent.From<SavedPostAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(SavedPostAdminSubscription.OnSavedPostAdminDeleted),
                        SavedPostAdminDeletedEvent.From<SavedPostAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(SavedPostAdminSubscription.OnSavedPostAdminChanged),
                SavedPostAdminChangedEvent.From<SavedPostAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
