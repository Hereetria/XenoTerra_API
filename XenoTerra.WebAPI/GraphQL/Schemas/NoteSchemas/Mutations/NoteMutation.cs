using FluentValidation;
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
            [Service] IValidator<CreateNoteInput> inputValidator,
            CreateNoteInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateNoteInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateNoteInput, CreateNoteDto>(input);
            var payload = await mutationService.CreateAsync<CreateNotePayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendNoteEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateNotePayload> UpdateNoteAsync(
            [Service] INoteMutationService mutationService,
            [Service] INoteWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateNoteInput> inputValidator,
            IResolverContext context,
            UpdateNoteInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateNoteInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateNoteInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateNoteInput, UpdateNoteDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateNotePayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendNoteEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteNotePayload> DeleteNoteAsync(
            [Service] INoteMutationService mutationService,
            [Service] INoteWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteNotePayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(NoteSubscription.OnNoteCreated),
                        NoteCreatedEvent.From<NoteCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(NoteSubscription.OnNoteUpdated),
                        NoteUpdatedEvent.From<NoteUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(NoteSubscription.OnNoteDeleted),
                        NoteDeletedEvent.From<NoteDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(NoteSubscription.OnNoteChanged),
                NoteChangedEvent.From<NoteChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
