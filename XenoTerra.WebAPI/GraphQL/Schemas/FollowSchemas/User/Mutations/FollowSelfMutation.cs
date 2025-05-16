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
    public class FollowSelfMutation
    {
        public async Task<CreateFollowSelfPayload> CreateFollowAsync(
            [Service] IFollowMutationService mutationService,
            [Service] IFollowWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreateFollowSelfInput> inputSelfValidator,
            CreateFollowSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateFollowSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateFollowSelfInput, CreateFollowDto>(input);
            var payload = await mutationService.CreateAsync<CreateFollowSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendFollowEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateFollowSelfPayload> UpdateFollowAsync(
            [Service] IFollowMutationService mutationService,
            [Service] IFollowWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateFollowSelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateFollowSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateFollowSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateFollowSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateFollowSelfInput, UpdateFollowDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateFollowSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendFollowEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteFollowSelfPayload> DeleteFollowAsync(
            [Service] IFollowMutationService mutationService,
            [Service] IFollowWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteFollowSelfPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(FollowSelfSubscription.OnFollowCreated),
                        FollowCreatedSelfEvent.From<FollowCreatedSelfEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(FollowSelfSubscription.OnFollowUpdated),
                        FollowUpdatedSelfEvent.From<FollowUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(FollowSelfSubscription.OnFollowDeleted),
                        FollowDeletedSelfEvent.From<FollowDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(FollowSelfSubscription.OnFollowChanged),
                FollowChangedSelfEvent.From<FollowChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
