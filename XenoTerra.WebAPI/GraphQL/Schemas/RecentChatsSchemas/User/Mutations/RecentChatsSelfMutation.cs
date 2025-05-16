using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.RecentChatsService;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.RecentChatsMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Mutations
{
    public class RecentChatsSelfMutation
    {
        public async Task<CreateRecentChatsSelfPayload> CreateRecentChatsAsync(
            [Service] IRecentChatsMutationService mutationService,
            [Service] IRecentChatsWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreateRecentChatsSelfInput> inputSelfValidator,
            CreateRecentChatsSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateRecentChatsSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateRecentChatsSelfInput, CreateRecentChatsDto>(input);
            var payload = await mutationService.CreateAsync<CreateRecentChatsSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendRecentChatsEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateRecentChatsSelfPayload> UpdateRecentChatsAsync(
            [Service] IRecentChatsMutationService mutationService,
            [Service] IRecentChatsWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateRecentChatsSelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateRecentChatsSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateRecentChatsSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateRecentChatsSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateRecentChatsSelfInput, UpdateRecentChatsDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateRecentChatsSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendRecentChatsEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteRecentChatsSelfPayload> DeleteRecentChatsAsync(
            [Service] IRecentChatsMutationService mutationService,
            [Service] IRecentChatsWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteRecentChatsSelfPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(RecentChatsSelfSubscription.OnRecentChatsCreated),
                        RecentChatsCreatedSelfEvent.From<RecentChatsCreatedSelfEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(RecentChatsSelfSubscription.OnRecentChatsUpdated),
                        RecentChatsUpdatedSelfEvent.From<RecentChatsUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(RecentChatsSelfSubscription.OnRecentChatsDeleted),
                        RecentChatsDeletedSelfEvent.From<RecentChatsDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(RecentChatsSelfSubscription.OnRecentChatsChanged),
                RecentChatsChangedSelfEvent.From<RecentChatsChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }

}
