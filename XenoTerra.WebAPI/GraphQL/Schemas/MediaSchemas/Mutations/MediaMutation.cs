using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.MediaService;
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.MediaMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Mutations
{
    public class MediaMutation
    {
        public async Task<CreateMediaPayload> CreateMediaAsync(
            [Service] IMediaMutationService mutationService,
            [Service] IMediaWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateMediaInput> inputValidator,
            CreateMediaInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateMediaInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateMediaInput, CreateMediaDto>(input);
            var payload = await mutationService.CreateAsync<CreateMediaPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendMediaEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateMediaPayload> UpdateMediaAsync(
            [Service] IMediaMutationService mutationService,
            [Service] IMediaWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateMediaInput> inputValidator,
            IResolverContext context,
            UpdateMediaInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateMediaInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateMediaInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateMediaInput, UpdateMediaDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateMediaPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendMediaEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteMediaPayload> DeleteMediaAsync(
            [Service] IMediaMutationService mutationService,
            [Service] IMediaWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteMediaPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(MediaSubscription.OnMediaCreated),
                        MediaCreatedEvent.From<MediaCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(MediaSubscription.OnMediaUpdated),
                        MediaUpdatedEvent.From<MediaUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(MediaSubscription.OnMediaDeleted),
                        MediaDeletedEvent.From<MediaDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(MediaSubscription.OnMediaChanged),
                MediaChangedEvent.From<MediaChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
