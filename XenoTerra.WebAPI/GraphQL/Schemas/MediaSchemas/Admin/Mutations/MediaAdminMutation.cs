using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.MediaServices;
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.MediaMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class MediaAdminMutation
    {
        public async Task<CreateMediaAdminPayload> CreateMediaAsync(
            [Service] IMediaAdminMutationService mutationService,
            [Service] IMediaWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateMediaAdminInput> inputAdminValidator,
            CreateMediaAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateMediaAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateMediaAdminInput, CreateMediaDto>(input);
            var payload = await mutationService.CreateAsync<CreateMediaAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendMediaEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateMediaAdminPayload> UpdateMediaAsync(
            [Service] IMediaAdminMutationService mutationService,
            [Service] IMediaWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateMediaAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateMediaAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateMediaAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateMediaAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateMediaAdminInput, UpdateMediaDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateMediaAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendMediaEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteMediaAdminPayload> DeleteMediaAsync(
            [Service] IMediaAdminMutationService mutationService,
            [Service] IMediaWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteMediaAdminPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendMediaEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendMediaEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultMediaDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(MediaAdminSubscription.OnMediaAdminCreated),
                        MediaAdminCreatedEvent.From<MediaAdminCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(MediaAdminSubscription.OnMediaAdminUpdated),
                        MediaAdminUpdatedEvent.From<MediaAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(MediaAdminSubscription.OnMediaAdminDeleted),
                        MediaAdminDeletedEvent.From<MediaAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(MediaAdminSubscription.OnMediaAdminChanged),
                MediaAdminChangedEvent.From<MediaAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
