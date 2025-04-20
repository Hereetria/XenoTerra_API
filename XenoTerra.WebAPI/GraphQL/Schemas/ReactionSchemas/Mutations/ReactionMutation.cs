using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReactionService;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.ReactionMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Mutations
{
    public class ReactionMutation
    {
        public async Task<CreateReactionPayload> CreateReactionAsync(
            [Service] IReactionMutationService mutationService,
            [Service] IReactionWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            CreateReactionInput? input)
        {
            if (!InputValidator.ValidateInputFields<Reaction, CreateReactionInput, ResultReactionDto, CreateReactionPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateReactionInput, CreateReactionDto>(input);
            var payload = await mutationService.CreateAsync<CreateReactionPayload>(writeService, createDto);

            await SendReactionCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateReactionPayload> UpdateReactionAsync(
            [Service] IReactionMutationService mutationService,
            [Service] IReactionWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateReactionInput? input)
        {
            if (!InputValidator.ValidateInputFields<Reaction, UpdateReactionInput, ResultReactionDto, UpdateReactionPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateReactionInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateReactionInput, UpdateReactionDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateReactionPayload>(writeService, updateDto, modifiedFields);

            await SendReactionUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteReactionPayload> DeleteReactionAsync(
            [Service] IReactionMutationService mutationService,
            [Service] IReactionWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<Reaction, ResultReactionDto, DeleteReactionPayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteReactionPayload>(writeService, parsedKey);

            await SendReactionDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendReactionCreatedEvents(ITopicEventSender sender, ResultReactionDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(ReactionSubscription.OnReactionCreated),
                ReactionCreatedEvent.From<ReactionCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(ReactionSubscription.OnReactionChanged),
                ReactionChangedEvent.From<ReactionChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendReactionUpdatedEvents(ITopicEventSender sender, ResultReactionDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(ReactionSubscription.OnReactionUpdated),
                ReactionUpdatedEvent.From<ReactionUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(ReactionSubscription.OnReactionChanged),
                ReactionChangedEvent.From<ReactionChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendReactionDeletedEvents(ITopicEventSender sender, ResultReactionDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(ReactionSubscription.OnReactionDeleted),
                ReactionDeletedEvent.From<ReactionDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(ReactionSubscription.OnReactionChanged),
                ReactionChangedEvent.From<ReactionChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}
