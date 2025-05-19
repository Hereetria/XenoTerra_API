using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.NoteServices;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.NoteMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class NoteAdminMutation
    {
        public async Task<CreateNoteAdminPayload> CreateNoteAsync(
            [Service] INoteAdminMutationService mutationService,
            [Service] INoteWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateNoteAdminInput> inputAdminValidator,
            CreateNoteAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateNoteAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateNoteAdminInput, CreateNoteDto>(input);
            var payload = await mutationService.CreateAsync<CreateNoteAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendNoteEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateNoteAdminPayload> UpdateNoteAsync(
            [Service] INoteAdminMutationService mutationService,
            [Service] INoteWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateNoteAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateNoteAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateNoteAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateNoteAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateNoteAdminInput, UpdateNoteDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateNoteAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendNoteEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteNoteAdminPayload> DeleteNoteAsync(
            [Service] INoteAdminMutationService mutationService,
            [Service] INoteWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteNoteAdminPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(NoteAdminSubscription.OnNoteAdminCreated),
                        NoteAdminCreatedEvent.From<NoteAdminCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(NoteAdminSubscription.OnNoteAdminUpdated),
                        NoteAdminUpdatedEvent.From<NoteAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(NoteAdminSubscription.OnNoteAdminDeleted),
                        NoteAdminDeletedEvent.From<NoteAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(NoteAdminSubscription.OnNoteAdminChanged),
                NoteAdminChangedEvent.From<NoteAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
