using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.SavedPostServices;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.SavedPostMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class SavedPostSelfMutation
    {
        public async Task<CreateSavedPostSelfPayload> CreateMySavedPostAsync(
            [Service] ISavedPostSelfMutationService mutationService,
            [Service] ISavedPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateSavedPostSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateSavedPostSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateSavedPostSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateSavedPostSelfInput, CreateSavedPostDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateSavedPostSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendSavedPostEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateSavedPostSelfPayload> UpdateMySavedPostAsync(
            [Service] ISavedPostSelfMutationService mutationService,
            [Service] ISavedPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateSavedPostSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateSavedPostSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateSavedPostSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateSavedPostSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateSavedPostSelfInput, UpdateSavedPostDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateSavedPostSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendSavedPostEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteSavedPostSelfPayload> DeleteMySavedPostAsync(
            [Service] ISavedPostSelfMutationService mutationService,
            [Service] ISavedPostReadService readService,
            [Service] ISavedPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var savedPost = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.UserId
            );

            if (savedPost.UserId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteSavedPostSelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendSavedPostEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendSavedPostEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultSavedPostDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(SavedPostSelfSubscription.OnSavedPostSelfCreated),
                        SavedPostSelfCreatedEvent.From<SavedPostSelfCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(SavedPostSelfSubscription.OnSavedPostSelfUpdated),
                        SavedPostSelfUpdatedEvent.From<SavedPostSelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(SavedPostSelfSubscription.OnSavedPostSelfDeleted),
                        SavedPostSelfDeletedEvent.From<SavedPostSelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(SavedPostSelfSubscription.OnSavedPostSelfChanged),
                SavedPostSelfChangedEvent.From<SavedPostSelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

