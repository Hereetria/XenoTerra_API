using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserService;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.UserMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Mutations
{
    public class UserSelfMutation
    {
        //public async Task<CreateUserSelfPayload> CreateUserAsync(
        //    [Service] IUserMutationService mutationService,
        //    [Service] ITopicEventSender eventSender,
        //    [Service] ISelfValidator<CreateUserSelfInput> inputSelfValidator,
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

        public async Task<UpdateUserSelfPayload> UpdateUserAsync(
            [Service] IUserMutationService mutationService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateUserSelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateUserSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateUserSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateUserSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateUserSelfInput, UpdateUserDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync(updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendUserEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteUserSelfPayload> DeleteUserAsync(
            [Service] IUserMutationService mutationService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync(parsedKey);

            if (payload.IsSuccess())
                await SendUserEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendUserEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultUserDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(UserSelfSubscription.OnUserCreated),
                        UserCreatedSelfEvent.From<UserCreatedSelfEvent>(result, userId, now));
                    break;
                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(UserSelfSubscription.OnUserUpdated),
                        UserUpdatedSelfEvent.From<UserUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;
                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(UserSelfSubscription.OnUserDeleted),
                        UserDeletedSelfEvent.From<UserDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(UserSelfSubscription.OnUserChanged),
                UserChangedSelfEvent.From<UserChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
