using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.UserMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class AppUserOwnMutation
    {
        //public async Task<CreateUserOwnPayload> CreateMyUserAsync(
        //    [Service] IUserOwnMutationService mutationService,
        //    [Service] ITopicEventSender eventSender,
        //    [Service] IValidator<CreateUserOwnInput> inputOwnValidator,
        //    CreateUserOwnInput? input)
        //{
        //    InputGuard.EnsureNotNull(input, nameof(CreateUserOwnInput));
        //    await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

        //    var createDto = DtoMapperHelper.MapInputToDto<CreateUserOwnInput, >(input);
        //    var payload = await mutationService.CreateAsync(createDto);

        //    if (payload.IsSuccess())
        //        await SendUserEventAsync(eventSender, ChangedEventType.Created, payload.Result);

        //    return payload;
        //}

        public async Task<UpdateUserOwnPayload> UpdateMyUserAsync(
            [Service] IUserOwnMutationService mutationService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateUserOwnInput> inputOwnValidator,
            [Service] HttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateUserOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateUserOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateUserOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateUserOwnInput, UpdateAppUserOwnDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var payload = await mutationService.UpdateAsync(updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendUserEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteUserOwnPayload> DeleteMyUserAsync(
            [Service] IUserOwnMutationService mutationService,
            [Service] ITopicEventSender eventSender,
            [Service] HttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var payload = await mutationService.DeleteAsync(parsedKey);

            if (payload.IsSuccess())
                await SendUserEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }

        private async Task SendUserEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultAppUserOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(AppUserOwnSubscription.OnUserOwnCreated),
                        UserOwnCreatedEvent.From<UserOwnCreatedEvent>(result, userId, now));
                    break;
                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(AppUserOwnSubscription.OnUserOwnUpdated),
                        UserOwnUpdatedEvent.From<UserOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;
                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(AppUserOwnSubscription.OnUserOwnDeleted),
                        UserOwnDeletedEvent.From<UserOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(AppUserOwnSubscription.OnUserOwnChanged),
                UserOwnChangedEvent.From<UserOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
