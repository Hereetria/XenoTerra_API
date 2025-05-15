using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReactionService;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.ReactionMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Mutations
{
    public class ReactionMutation
    {
        public async Task<CreateReactionPayload> CreateReactionAsync(
            [Service] IReactionMutationService mutationService,
            [Service] IReactionWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateReactionInput> inputValidator,
            CreateReactionInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateReactionInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateReactionInput, CreateReactionDto>(input);
            var payload = await mutationService.CreateAsync<CreateReactionPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendReactionEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateReactionPayload> UpdateReactionAsync(
            [Service] IReactionMutationService mutationService,
            [Service] IReactionWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateReactionInput> inputValidator,
            IResolverContext context,
            UpdateReactionInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateReactionInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateReactionInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateReactionInput, UpdateReactionDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateReactionPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendReactionEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteReactionPayload> DeleteReactionAsync(
            [Service] IReactionMutationService mutationService,
            [Service] IReactionWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteReactionPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendReactionEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendReactionEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultReactionDto result,
            IEnumerable<string>? modifiedFields = null)
        {

            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(ReactionSubscription.OnReactionCreated),
                        ReactionCreatedEvent.From<ReactionCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ReactionSubscription.OnReactionUpdated),
                        ReactionUpdatedEvent.From<ReactionUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ReactionSubscription.OnReactionDeleted),
                        ReactionDeletedEvent.From<ReactionDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ReactionSubscription.OnReactionChanged),
                ReactionChangedEvent.From<ReactionChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
