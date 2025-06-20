using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Own.NoteMutationServices;
using XenoTerra.DTOLayer.Dtos.NoteAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Mutations.Inputs;
using XenoTerra.BussinessLogicLayer.Services.Entity.NoteServices.Read;
using XenoTerra.BussinessLogicLayer.Services.Entity.NoteServices.Write.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class NoteOwnMutation
    {
        public async Task<CreateNoteOwnPayload> CreateOwnNoteAsync(
            [Service] INoteOwnMutationService mutationService,
            [Service] INoteOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateNoteOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateNoteOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateNoteOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateNoteOwnInput, CreateNoteOwnDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateNoteOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendNoteEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateNoteOwnPayload> UpdateOwnNoteAsync(
            [Service] INoteOwnMutationService mutationService,
            [Service] INoteOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateNoteOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateNoteOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateNoteOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateNoteOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateNoteOwnInput, UpdateNoteOwnDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateNoteOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendNoteEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteNoteOwnPayload> DeleteOwnNoteAsync(
            [Service] INoteOwnMutationService mutationService,
            [Service] INoteReadService readService,
            [Service] INoteOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var note = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.UserId
            );

            if (note.UserId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteNoteOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendNoteEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendNoteEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultNoteOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(NoteOwnSubscription.OnNoteOwnCreated),
                        NoteOwnCreatedEvent.From<NoteOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(NoteOwnSubscription.OnNoteOwnUpdated),
                        NoteOwnUpdatedEvent.From<NoteOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(NoteOwnSubscription.OnNoteOwnDeleted),
                        NoteOwnDeletedEvent.From<NoteOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(NoteOwnSubscription.OnNoteOwnChanged),
                NoteOwnChangedEvent.From<NoteOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

