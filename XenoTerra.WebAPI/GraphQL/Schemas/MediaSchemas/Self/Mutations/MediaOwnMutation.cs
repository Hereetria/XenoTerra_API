using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Own.MediaMutationServices;
using XenoTerra.DTOLayer.Dtos.MediaAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Mutations.Inputs;
using XenoTerra.BussinessLogicLayer.Services.Entity.MediaServices.Write.Own;
using XenoTerra.BussinessLogicLayer.Services.Entity.MediaServices.Read;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class MediaOwnMutation
    {
        public async Task<CreateMediaOwnPayload> CreateOwnMediaAsync(
            [Service] IMediaOwnMutationService mutationService,
            [Service] IMediaOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateMediaOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateMediaOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateMediaOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateMediaOwnInput, CreateMediaOwnDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;
            var payload = await mutationService.CreateAsync<CreateMediaOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendMediaEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateMediaOwnPayload> UpdateOwnMediaAsync(
            [Service] IMediaOwnMutationService mutationService,
            [Service] IMediaOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateMediaOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateMediaOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateMediaOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateMediaOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateMediaOwnInput, UpdateMediaOwnDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateMediaOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendMediaEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteMediaOwnPayload> DeleteOwnMediaAsync(
            [Service] IMediaOwnMutationService mutationService,
            [Service] IMediaReadService readService,
            [Service] IMediaOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var media = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.SenderId
            );

            if (media.SenderId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteMediaOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendMediaEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendMediaEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultMediaOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(MediaOwnSubscription.OnMediaOwnCreated),
                        MediaOwnCreatedEvent.From<MediaOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(MediaOwnSubscription.OnMediaOwnUpdated),
                        MediaOwnUpdatedEvent.From<MediaOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(MediaOwnSubscription.OnMediaOwnDeleted),
                        MediaOwnDeletedEvent.From<MediaOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(MediaOwnSubscription.OnMediaOwnChanged),
                MediaOwnChangedEvent.From<MediaOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

