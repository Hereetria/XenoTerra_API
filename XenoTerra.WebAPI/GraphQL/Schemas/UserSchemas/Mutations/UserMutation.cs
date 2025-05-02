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
    public class UserMutation
    {
        public async Task<CreateUserPayload> CreateUserAsync(
            [Service] IUserMutationService mutationService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateUserInput> inputValidator,
            CreateUserInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateUserInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateUserInput, CreateUserDto>(input);
            var payload = await mutationService.CreateAsync(createDto);

            if (payload.IsSuccess())
                await SendUserEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateUserPayload> UpdateUserAsync(
            [Service] IUserMutationService mutationService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateUserInput> inputValidator,
            IResolverContext context,
            UpdateUserInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateUserInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateUserInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateUserInput, UpdateUserDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync(updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendUserEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteUserPayload> DeleteUserAsync(
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
                    await sender.SendAsync(nameof(UserSubscription.OnUserCreated),
                        UserCreatedEvent.From<UserCreatedEvent>(result, userId, now));
                    break;
                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(UserSubscription.OnUserUpdated),
                        UserUpdatedEvent.From<UserUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;
                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(UserSubscription.OnUserDeleted),
                        UserDeletedEvent.From<UserDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(UserSubscription.OnUserChanged),
                UserChangedEvent.From<UserChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
