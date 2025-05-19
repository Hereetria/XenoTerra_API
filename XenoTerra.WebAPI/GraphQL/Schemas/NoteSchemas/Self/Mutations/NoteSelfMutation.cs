using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.NoteServices;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.NoteMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class NoteSelfMutation
    {
        public async Task<CreateNoteSelfPayload> CreateMyNoteAsync(
            [Service] INoteSelfMutationService mutationService,
            [Service] INoteWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateNoteSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateNoteSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateNoteSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateNoteSelfInput, CreateNoteDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateNoteSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendNoteEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateNoteSelfPayload> UpdateMyNoteAsync(
            [Service] INoteSelfMutationService mutationService,
            [Service] INoteWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateNoteSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateNoteSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateNoteSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateNoteSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateNoteSelfInput, UpdateNoteDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateNoteSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendNoteEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteNoteSelfPayload> DeleteMyNoteAsync(
            [Service] INoteSelfMutationService mutationService,
            [Service] INoteReadService readService,
            [Service] INoteWriteService writeService,
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

            var payload = await mutationService.DeleteAsync<DeleteNoteSelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendNoteEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendNoteEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultNoteDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(NoteSelfSubscription.OnNoteSelfCreated),
                        NoteSelfCreatedEvent.From<NoteSelfCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(NoteSelfSubscription.OnNoteSelfUpdated),
                        NoteSelfUpdatedEvent.From<NoteSelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(NoteSelfSubscription.OnNoteSelfDeleted),
                        NoteSelfDeletedEvent.From<NoteSelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(NoteSelfSubscription.OnNoteSelfChanged),
                NoteSelfChangedEvent.From<NoteSelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

