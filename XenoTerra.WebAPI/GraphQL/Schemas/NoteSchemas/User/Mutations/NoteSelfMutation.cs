using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.NoteService;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.NoteMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations
{
    public class NoteSelfMutation
    {
        public async Task<CreateNoteSelfPayload> CreateNoteAsync(
            [Service] INoteMutationService mutationService,
            [Service] INoteWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreateNoteSelfInput> inputSelfValidator,
            CreateNoteSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateNoteSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateNoteSelfInput, CreateNoteDto>(input);
            var payload = await mutationService.CreateAsync<CreateNoteSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendNoteEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateNoteSelfPayload> UpdateNoteAsync(
            [Service] INoteMutationService mutationService,
            [Service] INoteWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateNoteSelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateNoteSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateNoteSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateNoteSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateNoteSelfInput, UpdateNoteDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateNoteSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendNoteEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteNoteSelfPayload> DeleteNoteAsync(
            [Service] INoteMutationService mutationService,
            [Service] INoteWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteNoteSelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendNoteEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendNoteEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultNoteDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(NoteSelfSubscription.OnNoteCreated),
                        NoteCreatedSelfEvent.From<NoteCreatedSelfEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(NoteSelfSubscription.OnNoteUpdated),
                        NoteUpdatedSelfEvent.From<NoteUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(NoteSelfSubscription.OnNoteDeleted),
                        NoteDeletedSelfEvent.From<NoteDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(NoteSelfSubscription.OnNoteChanged),
                NoteChangedSelfEvent.From<NoteChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
