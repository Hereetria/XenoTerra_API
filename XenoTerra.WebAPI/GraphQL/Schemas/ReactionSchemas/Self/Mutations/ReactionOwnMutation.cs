using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Own.ReactionMutationServices;
using XenoTerra.DTOLayer.Dtos.ReactionAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Mutations.Inputs;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReactionServices.Read;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReactionServices.Write.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class ReactionOwnMutation
    {
        public async Task<CreateReactionOwnPayload> CreateOwnReactionAsync(
            [Service] IReactionOwnMutationService mutationService,
            [Service] IReactionOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateReactionOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateReactionOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateReactionOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateReactionOwnInput, CreateReactionOwnDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateReactionOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendReactionEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateReactionOwnPayload> UpdateOwnReactionAsync(
            [Service] IReactionOwnMutationService mutationService,
            [Service] IReactionOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateReactionOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateReactionOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateReactionOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateReactionOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateReactionOwnInput, UpdateReactionOwnDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateReactionOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendReactionEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteReactionOwnPayload> DeleteOwnReactionAsync(
            [Service] IReactionOwnMutationService mutationService,
            [Service] IReactionReadService readService,
            [Service] IReactionOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var reaction = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.Message.SenderId
            );

            if (reaction.Message.SenderId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteReactionOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendReactionEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendReactionEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultReactionOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(ReactionOwnSubscription.OnReactionOwnCreated),
                        ReactionOwnCreatedEvent.From<ReactionOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ReactionOwnSubscription.OnReactionOwnUpdated),
                        ReactionOwnUpdatedEvent.From<ReactionOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ReactionOwnSubscription.OnReactionOwnDeleted),
                        ReactionOwnDeletedEvent.From<ReactionOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ReactionOwnSubscription.OnReactionOwnChanged),
                ReactionOwnChangedEvent.From<ReactionOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

