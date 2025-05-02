using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.RecentChatsService;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.RecentChatsMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Mutations
{
    public class RecentChatsMutation
    {
        public async Task<CreateRecentChatsPayload> CreateRecentChatsAsync(
            [Service] IRecentChatsMutationService mutationService,
            [Service] IRecentChatsWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateRecentChatsInput> inputValidator,
            CreateRecentChatsInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateRecentChatsInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateRecentChatsInput, CreateRecentChatsDto>(input);
            var payload = await mutationService.CreateAsync<CreateRecentChatsPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendRecentChatsEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateRecentChatsPayload> UpdateRecentChatsAsync(
            [Service] IRecentChatsMutationService mutationService,
            [Service] IRecentChatsWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateRecentChatsInput> inputValidator,
            IResolverContext context,
            UpdateRecentChatsInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateRecentChatsInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateRecentChatsInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateRecentChatsInput, UpdateRecentChatsDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateRecentChatsPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendRecentChatsEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteRecentChatsPayload> DeleteRecentChatsAsync(
            [Service] IRecentChatsMutationService mutationService,
            [Service] IRecentChatsWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteRecentChatsPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendRecentChatsEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendRecentChatsEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultRecentChatsDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(RecentChatsSubscription.OnRecentChatsCreated),
                        RecentChatsCreatedEvent.From<RecentChatsCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(RecentChatsSubscription.OnRecentChatsUpdated),
                        RecentChatsUpdatedEvent.From<RecentChatsUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(RecentChatsSubscription.OnRecentChatsDeleted),
                        RecentChatsDeletedEvent.From<RecentChatsDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(RecentChatsSubscription.OnRecentChatsChanged),
                RecentChatsChangedEvent.From<RecentChatsChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }

}
