using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserPostTagServices;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.UserPostTagMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Mutations
{
    public class UserPostTagMutation
    {
        public async Task<CreateUserPostTagPayload> CreateUserPostTagAsync(
            [Service] IUserPostTagMutationService mutationService,
            [Service] IUserPostTagWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateUserPostTagInput> inputValidator,
            CreateUserPostTagInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateUserPostTagInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateUserPostTagInput, CreateUserPostTagDto>(input);
            var payload = await mutationService.CreateAsync<CreateUserPostTagPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendUserPostTagEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateUserPostTagPayload> UpdateUserPostTagAsync(
            [Service] IUserPostTagMutationService mutationService,
            [Service] IUserPostTagWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateUserPostTagInput> inputValidator,
            IResolverContext context,
            UpdateUserPostTagInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateUserPostTagInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateUserPostTagInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateUserPostTagInput, UpdateUserPostTagDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateUserPostTagPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendUserPostTagEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteUserPostTagPayload> DeleteUserPostTagAsync(
            [Service] IUserPostTagMutationService mutationService,
            [Service] IUserPostTagWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var payload = await mutationService.DeleteAsync<DeleteUserPostTagPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendUserPostTagEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendUserPostTagEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultUserPostTagDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(UserPostTagSubscription.OnUserPostTagCreated),
                        UserPostTagCreatedEvent.From<UserPostTagCreatedEvent>(result, userId, now));
                    break;
                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(UserPostTagSubscription.OnUserPostTagUpdated),
                        UserPostTagUpdatedEvent.From<UserPostTagUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;
                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(UserPostTagSubscription.OnUserPostTagDeleted),
                        UserPostTagDeletedEvent.From<UserPostTagDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(UserPostTagSubscription.OnUserPostTagChanged),
                UserPostTagChangedEvent.From<UserPostTagChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
