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
            IResolverContext context,
            CreateMediaInput? input)
        {
            if (!InputValidator.ValidateInputFields<Media, CreateMediaInput, ResultMediaDto, CreateMediaPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateMediaInput, CreateMediaDto>(input);
            var payload = await mutationService.CreateAsync<CreateMediaPayload>(writeService, createDto);

            await SendMediaCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateMediaPayload> UpdateMediaAsync(
            [Service] IMediaMutationService mutationService,
            [Service] IMediaWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateMediaInput? input)
        {
            if (!InputValidator.ValidateInputFields<Media, UpdateMediaInput, ResultMediaDto, UpdateMediaPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateMediaInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateMediaInput, UpdateMediaDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateMediaPayload>(writeService, updateDto, modifiedFields);

            await SendMediaUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteMediaPayload> DeleteMediaAsync(
            [Service] IMediaMutationService mutationService,
            [Service] IMediaWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<Media, ResultMediaDto, DeleteMediaPayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteMediaPayload>(writeService, parsedKey);

            await SendMediaDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendMediaCreatedEvents(ITopicEventSender sender, ResultMediaDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(MediaSubscription.OnMediaCreated),
                MediaCreatedEvent.From<MediaCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(MediaSubscription.OnMediaChanged),
                MediaChangedEvent.From<MediaChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendMediaUpdatedEvents(ITopicEventSender sender, ResultMediaDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(MediaSubscription.OnMediaUpdated),
                MediaUpdatedEvent.From<MediaUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(MediaSubscription.OnMediaChanged),
                MediaChangedEvent.From<MediaChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendMediaDeletedEvents(ITopicEventSender sender, ResultMediaDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(MediaSubscription.OnMediaDeleted),
                MediaDeletedEvent.From<MediaDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(MediaSubscription.OnMediaChanged),
                MediaChangedEvent.From<MediaChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}
