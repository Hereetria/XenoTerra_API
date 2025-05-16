using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.MediaService;
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.MediaMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Mutations
{
    public class MediaSelfMutation
    {
        public async Task<CreateMediaSelfPayload> CreateMediaAsync(
            [Service] IMediaMutationService mutationService,
            [Service] IMediaWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreateMediaSelfInput> inputSelfValidator,
            CreateMediaSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateMediaSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateMediaSelfInput, CreateMediaDto>(input);
            var payload = await mutationService.CreateAsync<CreateMediaSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendMediaEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateMediaSelfPayload> UpdateMediaAsync(
            [Service] IMediaMutationService mutationService,
            [Service] IMediaWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateMediaSelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateMediaSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateMediaSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateMediaSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateMediaSelfInput, UpdateMediaDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateMediaSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendMediaEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteMediaSelfPayload> DeleteMediaAsync(
            [Service] IMediaMutationService mutationService,
            [Service] IMediaWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteMediaSelfPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(MediaSelfSubscription.OnMediaCreated),
                        MediaCreatedSelfEvent.From<MediaCreatedSelfEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(MediaSelfSubscription.OnMediaUpdated),
                        MediaUpdatedSelfEvent.From<MediaUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(MediaSelfSubscription.OnMediaDeleted),
                        MediaDeletedSelfEvent.From<MediaDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(MediaSelfSubscription.OnMediaChanged),
                MediaChangedSelfEvent.From<MediaChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
