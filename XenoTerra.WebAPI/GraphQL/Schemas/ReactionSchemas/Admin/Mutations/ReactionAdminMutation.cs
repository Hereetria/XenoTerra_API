using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.ReactionMutationServices;
using XenoTerra.DTOLayer.Dtos.ReactionAdminDtos.Admin;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReactionServices.Write.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class ReactionAdminMutation
    {
        public async Task<CreateReactionAdminPayload> CreateReactionAsync(
            [Service] IReactionAdminMutationService mutationService,
            [Service] IReactionAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateReactionAdminInput> inputAdminValidator,
            CreateReactionAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateReactionAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateReactionAdminInput, CreateReactionAdminDto>(input);
            var payload = await mutationService.CreateAsync<CreateReactionAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendReactionEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateReactionAdminPayload> UpdateReactionAsync(
            [Service] IReactionAdminMutationService mutationService,
            [Service] IReactionAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateReactionAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateReactionAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateReactionAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateReactionAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateReactionAdminInput, UpdateReactionAdminDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateReactionAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendReactionEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteReactionAdminPayload> DeleteReactionAsync(
            [Service] IReactionAdminMutationService mutationService,
            [Service] IReactionAdminWriteService writeService,
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
            ResultReactionAdminDto result,
            IEnumerable<string>? modifiedFields = null)
        {

            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(ReactionAdminSubscription.OnReactionAdminCreated),
                        ReactionAdminCreatedEvent.From<ReactionAdminCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ReactionAdminSubscription.OnReactionAdminUpdated),
                        ReactionAdminUpdatedEvent.From<ReactionAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ReactionAdminSubscription.OnReactionAdminDeleted),
                        ReactionAdminDeletedEvent.From<ReactionAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ReactionAdminSubscription.OnReactionAdminChanged),
                ReactionAdminChangedEvent.From<ReactionAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
