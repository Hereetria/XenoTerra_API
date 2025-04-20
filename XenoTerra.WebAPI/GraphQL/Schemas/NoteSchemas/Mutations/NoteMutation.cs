using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.NoteService;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.NoteMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.NoteMutations
{
    public class NoteMutation
    {
        public async Task<CreateNotePayload> CreateNoteAsync(
            [Service] INoteMutationService mutationService,
            [Service] INoteWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            CreateNoteInput? input)
        {
            if (!InputValidator.ValidateInputFields<Note, CreateNoteInput, ResultNoteDto, CreateNotePayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateNoteInput, CreateNoteDto>(input);
            var payload = await mutationService.CreateAsync<CreateNotePayload>(writeService, createDto);

            await SendNoteCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateNotePayload> UpdateNoteAsync(
            [Service] INoteMutationService mutationService,
            [Service] INoteWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateNoteInput? input)
        {
            if (!InputValidator.ValidateInputFields<Note, UpdateNoteInput, ResultNoteDto, UpdateNotePayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateNoteInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateNoteInput, UpdateNoteDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateNotePayload>(writeService, updateDto, modifiedFields);

            await SendNoteUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteNotePayload> DeleteNoteAsync(
            [Service] INoteMutationService mutationService,
            [Service] INoteWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<Note, ResultNoteDto, DeleteNotePayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteNotePayload>(writeService, parsedKey);

            await SendNoteDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendNoteCreatedEvents(ITopicEventSender sender, ResultNoteDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(NoteSubscription.OnNoteCreated),
                NoteCreatedEvent.From<NoteCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(NoteSubscription.OnNoteChanged),
                NoteChangedEvent.From<NoteChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendNoteUpdatedEvents(ITopicEventSender sender, ResultNoteDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(NoteSubscription.OnNoteUpdated),
                NoteUpdatedEvent.From<NoteUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(NoteSubscription.OnNoteChanged),
                NoteChangedEvent.From<NoteChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendNoteDeletedEvents(ITopicEventSender sender, ResultNoteDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(NoteSubscription.OnNoteDeleted),
                NoteDeletedEvent.From<NoteDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(NoteSubscription.OnNoteChanged),
                NoteChangedEvent.From<NoteChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}
