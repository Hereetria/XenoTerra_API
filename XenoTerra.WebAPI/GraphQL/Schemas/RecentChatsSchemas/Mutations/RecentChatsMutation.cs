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
            IResolverContext context,
            CreateRecentChatsInput? input)
        {
            if (!InputValidator.ValidateInputFields<RecentChats, CreateRecentChatsInput, ResultRecentChatsDto, CreateRecentChatsPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateRecentChatsInput, CreateRecentChatsDto>(input);
            var payload = await mutationService.CreateAsync<CreateRecentChatsPayload>(writeService, createDto);

            await SendRecentChatsCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateRecentChatsPayload> UpdateRecentChatsAsync(
            [Service] IRecentChatsMutationService mutationService,
            [Service] IRecentChatsWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateRecentChatsInput? input)
        {
            if (!InputValidator.ValidateInputFields<RecentChats, UpdateRecentChatsInput, ResultRecentChatsDto, UpdateRecentChatsPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateRecentChatsInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateRecentChatsInput, UpdateRecentChatsDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateRecentChatsPayload>(writeService, updateDto, modifiedFields);

            await SendRecentChatsUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteRecentChatsPayload> DeleteRecentChatsAsync(
            [Service] IRecentChatsMutationService mutationService,
            [Service] IRecentChatsWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<RecentChats, ResultRecentChatsDto, DeleteRecentChatsPayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteRecentChatsPayload>(writeService, parsedKey);

            await SendRecentChatsDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendRecentChatsCreatedEvents(ITopicEventSender sender, ResultRecentChatsDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(RecentChatsSubscription.OnRecentChatsCreated),
                RecentChatsCreatedEvent.From<RecentChatsCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(RecentChatsSubscription.OnRecentChatsChanged),
                RecentChatsChangedEvent.From<RecentChatsChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendRecentChatsUpdatedEvents(ITopicEventSender sender, ResultRecentChatsDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(RecentChatsSubscription.OnRecentChatsUpdated),
                RecentChatsUpdatedEvent.From<RecentChatsUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(RecentChatsSubscription.OnRecentChatsChanged),
                RecentChatsChangedEvent.From<RecentChatsChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendRecentChatsDeletedEvents(ITopicEventSender sender, ResultRecentChatsDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(RecentChatsSubscription.OnRecentChatsDeleted),
                RecentChatsDeletedEvent.From<RecentChatsDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(RecentChatsSubscription.OnRecentChatsChanged),
                RecentChatsChangedEvent.From<RecentChatsChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}
