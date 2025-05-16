using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.FollowService;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.FollowMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Mutations
{
    public class FollowAdminMutation
    {
        public async Task<CreateFollowAdminPayload> CreateFollowAsync(
            [Service] IFollowMutationService mutationService,
            [Service] IFollowWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<CreateFollowAdminInput> inputAdminValidator,
            CreateFollowAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateFollowAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateFollowAdminInput, CreateFollowDto>(input);
            var payload = await mutationService.CreateAsync<CreateFollowAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendFollowEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateFollowAdminPayload> UpdateFollowAsync(
            [Service] IFollowMutationService mutationService,
            [Service] IFollowWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<UpdateFollowAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateFollowAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateFollowAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateFollowAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateFollowAdminInput, UpdateFollowDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateFollowAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendFollowEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteFollowAdminPayload> DeleteFollowAsync(
            [Service] IFollowMutationService mutationService,
            [Service] IFollowWriteService writeService,
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
            ResultFollowDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(FollowAdminSubscription.OnFollowCreated),
                        FollowCreatedAdminEvent.From<FollowCreatedAdminEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(FollowAdminSubscription.OnFollowUpdated),
                        FollowUpdatedAdminEvent.From<FollowUpdatedAdminEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(FollowAdminSubscription.OnFollowDeleted),
                        FollowDeletedAdminEvent.From<FollowDeletedAdminEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(FollowAdminSubscription.OnFollowChanged),
                FollowChangedAdminEvent.From<FollowChangedAdminEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
