using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.FollowMutationServices;
using XenoTerra.DTOLayer.Dtos.FollowAdminDtos.Admin;
using XenoTerra.BussinessLogicLayer.Services.Entity.FollowServices.Write.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class FollowAdminMutation
    {
        public async Task<CreateFollowAdminPayload> CreateFollowAsync(
            [Service] IFollowAdminMutationService mutationService,
            [Service] IFollowAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateFollowAdminInput> inputAdminValidator,
            CreateFollowAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateFollowAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateFollowAdminInput, CreateFollowAdminDto>(input);
            var payload = await mutationService.CreateAsync<CreateFollowAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendFollowEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateFollowAdminPayload> UpdateFollowAsync(
            [Service] IFollowAdminMutationService mutationService,
            [Service] IFollowAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateFollowAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateFollowAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateFollowAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateFollowAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateFollowAdminInput, UpdateFollowAdminDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateFollowAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendFollowEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteFollowAdminPayload> DeleteFollowAsync(
            [Service] IFollowAdminMutationService mutationService,
            [Service] IFollowAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteFollowAdminPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendFollowEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendFollowEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultFollowAdminDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(FollowAdminSubscription.OnFollowAdminCreated),
                        FollowAdminCreatedEvent.From<FollowAdminCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(FollowAdminSubscription.OnFollowAdminUpdated),
                        FollowAdminUpdatedEvent.From<FollowAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(FollowAdminSubscription.OnFollowAdminDeleted),
                        FollowAdminDeletedEvent.From<FollowAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(FollowAdminSubscription.OnFollowAdminChanged),
                FollowAdminChangedEvent.From<FollowAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
