using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.MediaServices;
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.MediaMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class MediaSelfMutation
    {
        public async Task<CreateMediaSelfPayload> CreateMyMediaAsync(
            [Service] IMediaSelfMutationService mutationService,
            [Service] IMediaWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateMediaSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateMediaSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateMediaSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateMediaSelfInput, CreateMediaDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;
            var payload = await mutationService.CreateAsync<CreateMediaSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendMediaEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateMediaSelfPayload> UpdateMyMediaAsync(
            [Service] IMediaSelfMutationService mutationService,
            [Service] IMediaWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateMediaSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateMediaSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateMediaSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateMediaSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateMediaSelfInput, UpdateMediaDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateMediaSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendMediaEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteMediaSelfPayload> DeleteMyMediaAsync(
            [Service] IMediaSelfMutationService mutationService,
            [Service] IMediaReadService readService,
            [Service] IMediaWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var media = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.UserId
            );

            if (media.UserId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteMediaSelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendMediaEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendMediaEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultMediaDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(MediaSelfSubscription.OnMediaSelfCreated),
                        MediaSelfCreatedEvent.From<MediaSelfCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(MediaSelfSubscription.OnMediaSelfUpdated),
                        MediaSelfUpdatedEvent.From<MediaSelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(MediaSelfSubscription.OnMediaSelfDeleted),
                        MediaSelfDeletedEvent.From<MediaSelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(MediaSelfSubscription.OnMediaSelfChanged),
                MediaSelfChangedEvent.From<MediaSelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

