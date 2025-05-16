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
    public class ReactionAdminMutation
    {
        public async Task<CreateReactionAdminPayload> CreateReactionAsync(
            [Service] IReactionMutationService mutationService,
            [Service] IReactionWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<CreateReactionAdminInput> inputAdminValidator,
            CreateReactionAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateReactionAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateReactionAdminInput, CreateReactionDto>(input);
            var payload = await mutationService.CreateAsync<CreateReactionAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendReactionEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateReactionAdminPayload> UpdateReactionAsync(
            [Service] IReactionMutationService mutationService,
            [Service] IReactionWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<UpdateReactionAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateReactionAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateReactionAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateReactionAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateReactionAdminInput, UpdateReactionDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateReactionAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendReactionEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteReactionAdminPayload> DeleteReactionAsync(
            [Service] IReactionMutationService mutationService,
            [Service] IReactionWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteReactionAdminPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(ReactionAdminSubscription.OnReactionCreated),
                        ReactionCreatedAdminEvent.From<ReactionCreatedAdminEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ReactionAdminSubscription.OnReactionUpdated),
                        ReactionUpdatedAdminEvent.From<ReactionUpdatedAdminEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ReactionAdminSubscription.OnReactionDeleted),
                        ReactionDeletedAdminEvent.From<ReactionDeletedAdminEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ReactionAdminSubscription.OnReactionChanged),
                ReactionChangedAdminEvent.From<ReactionChangedAdminEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
