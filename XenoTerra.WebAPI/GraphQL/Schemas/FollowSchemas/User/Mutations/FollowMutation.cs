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
    public class FollowMutation
    {
        public async Task<CreateFollowPayload> CreateFollowAsync(
            [Service] IFollowMutationService mutationService,
            [Service] IFollowWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateFollowInput> inputValidator,
            CreateFollowInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateFollowInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateFollowInput, CreateFollowDto>(input);
            var payload = await mutationService.CreateAsync<CreateFollowPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendFollowEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateFollowPayload> UpdateFollowAsync(
            [Service] IFollowMutationService mutationService,
            [Service] IFollowWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateFollowInput> inputValidator,
            IResolverContext context,
            UpdateFollowInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateFollowInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateFollowInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateFollowInput, UpdateFollowDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateFollowPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendFollowEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteFollowPayload> DeleteFollowAsync(
            [Service] IFollowMutationService mutationService,
            [Service] IFollowWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteFollowPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(FollowSubscription.OnFollowCreated),
                        FollowCreatedEvent.From<FollowCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(FollowSubscription.OnFollowUpdated),
                        FollowUpdatedEvent.From<FollowUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(FollowSubscription.OnFollowDeleted),
                        FollowDeletedEvent.From<FollowDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(FollowSubscription.OnFollowChanged),
                FollowChangedEvent.From<FollowChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
