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
    public class ReactionSelfMutation
    {
        public async Task<CreateReactionSelfPayload> CreateReactionAsync(
            [Service] IReactionMutationService mutationService,
            [Service] IReactionWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreateReactionSelfInput> inputSelfValidator,
            CreateReactionSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateReactionSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateReactionSelfInput, CreateReactionDto>(input);
            var payload = await mutationService.CreateAsync<CreateReactionSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendReactionEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateReactionSelfPayload> UpdateReactionAsync(
            [Service] IReactionMutationService mutationService,
            [Service] IReactionWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateReactionSelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateReactionSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateReactionSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateReactionSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateReactionSelfInput, UpdateReactionDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateReactionSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendReactionEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteReactionSelfPayload> DeleteReactionAsync(
            [Service] IReactionMutationService mutationService,
            [Service] IReactionWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteReactionSelfPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(ReactionSelfSubscription.OnReactionCreated),
                        ReactionCreatedSelfEvent.From<ReactionCreatedSelfEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ReactionSelfSubscription.OnReactionUpdated),
                        ReactionUpdatedSelfEvent.From<ReactionUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ReactionSelfSubscription.OnReactionDeleted),
                        ReactionDeletedSelfEvent.From<ReactionDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ReactionSelfSubscription.OnReactionChanged),
                ReactionChangedSelfEvent.From<ReactionChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
