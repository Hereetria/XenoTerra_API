using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryServices;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.StoryMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class StorySelfMutation
    {
        public async Task<CreateStorySelfPayload> CreateMyStoryAsync(
            [Service] IStorySelfMutationService mutationService,
            [Service] IStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateStorySelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateStorySelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateStorySelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateStorySelfInput, CreateStoryDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateStorySelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendStoryEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateStorySelfPayload> UpdateMyStoryAsync(
            [Service] IStorySelfMutationService mutationService,
            [Service] IStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateStorySelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateStorySelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateStorySelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateStorySelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateStorySelfInput, UpdateStoryDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateStorySelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendStoryEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteStorySelfPayload> DeleteMyStoryAsync(
            [Service] IStorySelfMutationService mutationService,
            [Service] IStoryReadService readService,
            [Service] IStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var story = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.UserId
            );

            if (story.UserId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteStorySelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendStoryEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendStoryEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultStoryDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(StorySelfSubscription.OnStorySelfCreated),
                        StorySelfCreatedEvent.From<StorySelfCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(StorySelfSubscription.OnStorySelfUpdated),
                        StorySelfUpdatedEvent.From<StorySelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(StorySelfSubscription.OnStorySelfDeleted),
                        StorySelfDeletedEvent.From<StorySelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(StorySelfSubscription.OnStorySelfChanged),
                StorySelfChangedEvent.From<StorySelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

