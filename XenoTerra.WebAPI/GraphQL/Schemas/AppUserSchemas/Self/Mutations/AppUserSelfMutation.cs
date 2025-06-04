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
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.UserMutationServices;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Mutations.Payloads;
using XenoTerra.DTOLayer.Dtos.AppUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class AppUserSelfMutation
    {
        //public async Task<CreateUserSelfPayload> CreateMyUserAsync(
        //    [Service] IUserSelfMutationService mutationService,
        //    [Service] ITopicEventSender eventSender,
        //    [Service] IValidator<CreateUserSelfInput> inputSelfValidator,
        //    CreateUserSelfInput? input)
        //{
        //    InputGuard.EnsureNotNull(input, nameof(CreateUserSelfInput));
        //    await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

        //    var createDto = DtoMapperHelper.MapInputToDto<CreateUserSelfInput, >(input);
        //    var payload = await mutationService.CreateAsync(createDto);

        //    if (payload.IsSuccess())
        //        await SendUserEventAsync(eventSender, ChangedEventType.Created, payload.Result);

        //    return payload;
        //}

        public async Task<UpdateUserSelfPayload> UpdateMyUserAsync(
            [Service] IUserSelfMutationService mutationService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateUserSelfInput> inputSelfValidator,
            [Service] HttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateUserSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateUserSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateUserSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateUserSelfInput, UpdateAppUserDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var payload = await mutationService.UpdateAsync(updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendUserEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteUserSelfPayload> DeleteMyUserAsync(
            [Service] IUserSelfMutationService mutationService,
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
            ResultAppUserPrivateDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(AppUserSelfSubscription.OnUserSelfCreated),
                        UserSelfCreatedEvent.From<UserSelfCreatedEvent>(result, userId, now));
                    break;
                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(AppUserSelfSubscription.OnUserSelfUpdated),
                        UserSelfUpdatedEvent.From<UserSelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;
                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(AppUserSelfSubscription.OnUserSelfDeleted),
                        UserSelfDeletedEvent.From<UserSelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(AppUserSelfSubscription.OnUserSelfChanged),
                UserSelfChangedEvent.From<UserSelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
