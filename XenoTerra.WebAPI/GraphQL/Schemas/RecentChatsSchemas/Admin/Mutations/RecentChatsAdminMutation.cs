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
    public class RecentChatsAdminMutation
    {
        public async Task<CreateRecentChatsAdminPayload> CreateRecentChatsAsync(
            [Service] IRecentChatsMutationService mutationService,
            [Service] IRecentChatsWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<CreateRecentChatsAdminInput> inputAdminValidator,
            CreateRecentChatsAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateRecentChatsAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateRecentChatsAdminInput, CreateRecentChatsDto>(input);
            var payload = await mutationService.CreateAsync<CreateRecentChatsAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendRecentChatsEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateRecentChatsAdminPayload> UpdateRecentChatsAsync(
            [Service] IRecentChatsMutationService mutationService,
            [Service] IRecentChatsWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<UpdateRecentChatsAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateRecentChatsAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateRecentChatsAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateRecentChatsAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateRecentChatsAdminInput, UpdateRecentChatsDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateRecentChatsAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendRecentChatsEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteRecentChatsAdminPayload> DeleteRecentChatsAsync(
            [Service] IRecentChatsMutationService mutationService,
            [Service] IRecentChatsWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteRecentChatsAdminPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(RecentChatsAdminSubscription.OnRecentChatsCreated),
                        RecentChatsCreatedAdminEvent.From<RecentChatsCreatedAdminEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(RecentChatsAdminSubscription.OnRecentChatsUpdated),
                        RecentChatsUpdatedAdminEvent.From<RecentChatsUpdatedAdminEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(RecentChatsAdminSubscription.OnRecentChatsDeleted),
                        RecentChatsDeletedAdminEvent.From<RecentChatsDeletedAdminEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(RecentChatsAdminSubscription.OnRecentChatsChanged),
                RecentChatsChangedAdminEvent.From<RecentChatsChangedAdminEvent>(eventType, result, userId, now, modifiedFields));
        }
    }

}
