using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.StoryMutationServices;
using XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Admin;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryServices.Write.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class StoryAdminMutation
    {
        public async Task<CreateStoryAdminPayload> CreateStoryAsync(
            [Service] IStoryAdminMutationService mutationService,
            [Service] IStoryAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateStoryAdminInput> inputAdminValidator,
            CreateStoryAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateStoryAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateStoryAdminInput, CreateStoryAdminDto>(input);
            var payload = await mutationService.CreateAsync<CreateStoryAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendStoryEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateStoryAdminPayload> UpdateStoryAsync(
            [Service] IStoryAdminMutationService mutationService,
            [Service] IStoryAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateStoryAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateStoryAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateStoryAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateStoryAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateStoryAdminInput, UpdateStoryAdminDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateStoryAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendStoryEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteStoryAdminPayload> DeleteStoryAsync(
            [Service] IStoryAdminMutationService mutationService,
            [Service] IStoryAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var payload = await mutationService.DeleteAsync<DeleteStoryAdminPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendStoryEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendStoryEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultStoryAdminDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(StoryAdminSubscription.OnStoryAdminCreated),
                        StoryAdminCreatedEvent.From<StoryAdminCreatedEvent>(result, userId, now));
                    break;
                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(StoryAdminSubscription.OnStoryAdminUpdated),
                        StoryAdminUpdatedEvent.From<StoryAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;
                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(StoryAdminSubscription.OnStoryAdminDeleted),
                        StoryAdminDeletedEvent.From<StoryAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(StoryAdminSubscription.OnStoryAdminChanged),
                StoryAdminChangedEvent.From<StoryAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
