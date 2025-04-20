using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.LikeService;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.LikeMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Mutations
{
    public class LikeMutation
    {
        public async Task<CreateLikePayload> CreateLikeAsync(
            [Service] ILikeMutationService mutationService,
            [Service] ILikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            CreateLikeInput? input)
        {
            if (!InputValidator.ValidateInputFields<Like, CreateLikeInput, ResultLikeDto, CreateLikePayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateLikeInput, CreateLikeDto>(input);
            var payload = await mutationService.CreateAsync<CreateLikePayload>(writeService, createDto);

            await SendLikeCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateLikePayload> UpdateLikeAsync(
            [Service] ILikeMutationService mutationService,
            [Service] ILikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateLikeInput? input)
        {
            if (!InputValidator.ValidateInputFields<Like, UpdateLikeInput, ResultLikeDto, UpdateLikePayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateLikeInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateLikeInput, UpdateLikeDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateLikePayload>(writeService, updateDto, modifiedFields);

            await SendLikeUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteLikePayload> DeleteLikeAsync(
            [Service] ILikeMutationService mutationService,
            [Service] ILikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<Like, ResultLikeDto, DeleteLikePayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteLikePayload>(writeService, parsedKey);

            await SendLikeDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendLikeCreatedEvents(ITopicEventSender sender, ResultLikeDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(LikeSubscription.OnLikeCreated),
                LikeCreatedEvent.From<LikeCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(LikeSubscription.OnLikeChanged),
                LikeChangedEvent.From<LikeChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendLikeUpdatedEvents(ITopicEventSender sender, ResultLikeDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(LikeSubscription.OnLikeUpdated),
                LikeUpdatedEvent.From<LikeUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(LikeSubscription.OnLikeChanged),
                LikeChangedEvent.From<LikeChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendLikeDeletedEvents(ITopicEventSender sender, ResultLikeDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(LikeSubscription.OnLikeDeleted),
                LikeDeletedEvent.From<LikeDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(LikeSubscription.OnLikeChanged),
                LikeChangedEvent.From<LikeChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}
