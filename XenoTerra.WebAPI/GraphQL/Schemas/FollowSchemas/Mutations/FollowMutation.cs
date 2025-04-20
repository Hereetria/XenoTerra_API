using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.FollowService;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.FollowMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Mutations
{
    public class FollowMutation
    {
        public async Task<CreateFollowPayload> CreateFollowAsync(
            [Service] IFollowMutationService mutationService,
            [Service] IFollowWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            CreateFollowInput? input)
        {
            if (!InputValidator.ValidateInputFields<Follow, CreateFollowInput, ResultFollowDto, CreateFollowPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateFollowInput, CreateFollowDto>(input);
            var payload = await mutationService.CreateAsync<CreateFollowPayload>(writeService, createDto);

            await SendFollowCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateFollowPayload> UpdateFollowAsync(
            [Service] IFollowMutationService mutationService,
            [Service] IFollowWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateFollowInput? input)
        {
            if (!InputValidator.ValidateInputFields<Follow, UpdateFollowInput, ResultFollowDto, UpdateFollowPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateFollowInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateFollowInput, UpdateFollowDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateFollowPayload>(writeService, updateDto, modifiedFields);

            await SendFollowUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteFollowPayload> DeleteFollowAsync(
            [Service] IFollowMutationService mutationService,
            [Service] IFollowWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<Follow, ResultFollowDto, DeleteFollowPayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteFollowPayload>(writeService, parsedKey);

            await SendFollowDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendFollowCreatedEvents(ITopicEventSender sender, ResultFollowDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(FollowSubscription.OnFollowCreated),
                FollowCreatedEvent.From<FollowCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(FollowSubscription.OnFollowChanged),
                FollowChangedEvent.From<FollowChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendFollowUpdatedEvents(ITopicEventSender sender, ResultFollowDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(FollowSubscription.OnFollowUpdated),
                FollowUpdatedEvent.From<FollowUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(FollowSubscription.OnFollowChanged),
                FollowChangedEvent.From<FollowChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendFollowDeletedEvents(ITopicEventSender sender, ResultFollowDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(FollowSubscription.OnFollowDeleted),
                FollowDeletedEvent.From<FollowDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(FollowSubscription.OnFollowChanged),
                FollowChangedEvent.From<FollowChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}
