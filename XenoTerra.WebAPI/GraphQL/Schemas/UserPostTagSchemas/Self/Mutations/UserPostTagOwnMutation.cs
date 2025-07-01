using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Mutations.Inputs;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserPostTagServices.Read;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserPostTagServices.Write.Own;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Own;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.UserPostTagMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class UserPostTagOwnMutation
    {
        public async Task<CreateUserPostTagOwnPayload> CreateOwnUserPostTagAsync(
            [Service] IUserPostTagOwnMutationService mutationService,
            [Service] IUserPostTagOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateUserPostTagOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateUserPostTagOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateUserPostTagOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateUserPostTagOwnInput, CreateUserPostTagOwnDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateUserPostTagOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendUserPostTagEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateUserPostTagOwnPayload> UpdateOwnUserPostTagAsync(
            [Service] IUserPostTagOwnMutationService mutationService,
            [Service] IUserPostTagOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateUserPostTagOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateUserPostTagOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateUserPostTagOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateUserPostTagOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateUserPostTagOwnInput, UpdateUserPostTagOwnDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var payload = await mutationService.UpdateAsync<UpdateUserPostTagOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendUserPostTagEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteUserPostTagOwnPayload> DeleteOwnUserPostTagAsync(
            [Service] IUserPostTagOwnMutationService mutationService,
            [Service] IUserPostTagReadService readService,
            [Service] IUserPostTagOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var comment = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.UserId
            );

            if (comment.UserId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteUserPostTagOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendUserPostTagEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendUserPostTagEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultUserPostTagOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(UserPostTagOwnSubscription.OnUserPostTagOwnCreated),
                        UserPostTagOwnCreatedEvent.From<UserPostTagOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(UserPostTagOwnSubscription.OnUserPostTagOwnUpdated),
                        UserPostTagOwnUpdatedEvent.From<UserPostTagOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(UserPostTagOwnSubscription.OnUserPostTagOwnDeleted),
                        UserPostTagOwnDeletedEvent.From<UserPostTagOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(UserPostTagOwnSubscription.OnUserPostTagOwnChanged),
                UserPostTagOwnChangedEvent.From<UserPostTagOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}