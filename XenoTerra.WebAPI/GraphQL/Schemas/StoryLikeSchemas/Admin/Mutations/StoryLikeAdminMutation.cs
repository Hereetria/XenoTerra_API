using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.StoryLikeAdminMutationServices;
using XenoTerra.DTOLayer.Dtos.StoryLikeAdminDtos.Admin;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryLikeServices.Write.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class StoryLikeAdminMutation
    {
        public async Task<CreateStoryLikeAdminPayload> CreateStoryLikeAsync(
            [Service] IStoryLikeAdminMutationService mutationService,
            [Service] IStoryLikeAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateStoryLikeAdminInput> inputAdminValidator,
            CreateStoryLikeAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateStoryLikeAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateStoryLikeAdminInput, CreateStoryLikeAdminDto>(input);
            var payload = await mutationService.CreateAsync<CreateStoryLikeAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendStoryLikeEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateStoryLikeAdminPayload> UpdateStoryLikeAsync(
            [Service] IStoryLikeAdminMutationService mutationService,
            [Service] IStoryLikeAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateStoryLikeAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateStoryLikeAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateStoryLikeAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateStoryLikeAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateStoryLikeAdminInput, UpdateStoryLikeAdminDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateStoryLikeAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendStoryLikeEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteStoryLikeAdminPayload> DeleteStoryLikeAsync(
            [Service] IStoryLikeAdminMutationService mutationService,
            [Service] IStoryLikeAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteStoryLikeAdminPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendStoryLikeEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendStoryLikeEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultStoryLikeAdminDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(StoryLikeAdminSubscription.OnStoryLikeAdminCreated),
                        StoryLikeAdminCreatedEvent.From<StoryLikeAdminCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(StoryLikeAdminSubscription.OnStoryLikeAdminUpdated),
                        StoryLikeAdminUpdatedEvent.From<StoryLikeAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(StoryLikeAdminSubscription.OnStoryLikeAdminDeleted),
                        StoryLikeAdminDeletedEvent.From<StoryLikeAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(StoryLikeAdminSubscription.OnStoryLikeAdminChanged),
                StoryLikeAdminChangedEvent.From<StoryLikeAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
