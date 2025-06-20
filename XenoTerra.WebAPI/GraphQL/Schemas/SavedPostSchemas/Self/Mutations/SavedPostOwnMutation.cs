using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Own.SavedPostMutationServices;
using XenoTerra.DTOLayer.Dtos.SavedPostAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Mutations.Payloads;
using XenoTerra.BussinessLogicLayer.Services.Entity.SavedPostServices.Write.Own;
using XenoTerra.BussinessLogicLayer.Services.Entity.SavedPostServices.Read;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class SavedPostOwnMutation
    {
        public async Task<CreateSavedPostOwnPayload> CreateOwnSavedPostAsync(
            [Service] ISavedPostOwnMutationService mutationService,
            [Service] ISavedPostOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateSavedPostOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateSavedPostOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateSavedPostOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateSavedPostOwnInput, CreateSavedPostOwnDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateSavedPostOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendSavedPostEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateSavedPostOwnPayload> UpdateOwnSavedPostAsync(
            [Service] ISavedPostOwnMutationService mutationService,
            [Service] ISavedPostOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateSavedPostOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateSavedPostOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateSavedPostOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateSavedPostOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateSavedPostOwnInput, UpdateSavedPostOwnDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateSavedPostOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendSavedPostEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteSavedPostOwnPayload> DeleteOwnSavedPostAsync(
            [Service] ISavedPostOwnMutationService mutationService,
            [Service] ISavedPostReadService readService,
            [Service] ISavedPostOwnWriteService writeService,
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

            var payload = await mutationService.DeleteAsync<DeleteSavedPostOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendSavedPostEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendSavedPostEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultSavedPostOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(SavedPostOwnSubscription.OnSavedPostOwnCreated),
                        SavedPostOwnCreatedEvent.From<SavedPostOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(SavedPostOwnSubscription.OnSavedPostOwnUpdated),
                        SavedPostOwnUpdatedEvent.From<SavedPostOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(SavedPostOwnSubscription.OnSavedPostOwnDeleted),
                        SavedPostOwnDeletedEvent.From<SavedPostOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(SavedPostOwnSubscription.OnSavedPostOwnChanged),
                SavedPostOwnChangedEvent.From<SavedPostOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

