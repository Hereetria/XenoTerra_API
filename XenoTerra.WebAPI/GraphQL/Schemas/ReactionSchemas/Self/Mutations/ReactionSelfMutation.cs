using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReactionServices;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.ReactionMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class ReactionSelfMutation
    {
        public async Task<CreateReactionSelfPayload> CreateMyReactionAsync(
            [Service] IReactionSelfMutationService mutationService,
            [Service] IReactionWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateReactionSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateReactionSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateReactionSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateReactionSelfInput, CreateReactionDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateReactionSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendReactionEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateReactionSelfPayload> UpdateMyReactionAsync(
            [Service] IReactionSelfMutationService mutationService,
            [Service] IReactionWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateReactionSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateReactionSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateReactionSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateReactionSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateReactionSelfInput, UpdateReactionDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateReactionSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendReactionEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteReactionSelfPayload> DeleteMyReactionAsync(
            [Service] IReactionSelfMutationService mutationService,
            [Service] IReactionReadService readService,
            [Service] IReactionWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var reaction = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.UserId
            );

            if (reaction.UserId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteReactionSelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendReactionEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendReactionEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultReactionDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(ReactionSelfSubscription.OnReactionSelfCreated),
                        ReactionSelfCreatedEvent.From<ReactionSelfCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ReactionSelfSubscription.OnReactionSelfUpdated),
                        ReactionSelfUpdatedEvent.From<ReactionSelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ReactionSelfSubscription.OnReactionSelfDeleted),
                        ReactionSelfDeletedEvent.From<ReactionSelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ReactionSelfSubscription.OnReactionSelfChanged),
                ReactionSelfChangedEvent.From<ReactionSelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

