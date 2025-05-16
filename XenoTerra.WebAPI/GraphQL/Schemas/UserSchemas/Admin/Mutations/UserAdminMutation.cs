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
    public class UserAdminMutation
    {
        //public async Task<CreateUserAdminPayload> CreateUserAsync(
        //    [Service] IUserMutationService mutationService,
        //    [Service] ITopicEventSender eventSender,
        //    [Service] IAdminValidator<CreateUserAdminInput> inputAdminValidator,
        //    CreateUserAdminInput? input)
        //{
        //    InputGuard.EnsureNotNull(input, nameof(CreateUserAdminInput));
        //    await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

        //    var createDto = DtoMapperHelper.MapInputToDto<CreateUserAdminInput, >(input);
        //    var payload = await mutationService.CreateAsync(createDto);

        //    if (payload.IsSuccess())
        //        await SendUserEventAsync(eventSender, ChangedEventType.Created, payload.Result);

        //    return payload;
        //}

        public async Task<UpdateUserAdminPayload> UpdateUserAsync(
            [Service] IUserMutationService mutationService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<UpdateUserAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateUserAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateUserAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateUserAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateUserAdminInput, UpdateUserDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync(updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendUserEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteUserAdminPayload> DeleteUserAsync(
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
                    await sender.SendAsync(nameof(UserAdminSubscription.OnUserCreated),
                        UserCreatedAdminEvent.From<UserCreatedAdminEvent>(result, userId, now));
                    break;
                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(UserAdminSubscription.OnUserUpdated),
                        UserUpdatedAdminEvent.From<UserUpdatedAdminEvent>(result, userId, now, modifiedFields ?? []));
                    break;
                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(UserAdminSubscription.OnUserDeleted),
                        UserDeletedAdminEvent.From<UserDeletedAdminEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(UserAdminSubscription.OnUserChanged),
                UserChangedAdminEvent.From<UserChangedAdminEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
