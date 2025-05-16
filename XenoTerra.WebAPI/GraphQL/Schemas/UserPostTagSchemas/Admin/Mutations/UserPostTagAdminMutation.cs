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
    public class UserPostTagAdminMutation
    {
        public async Task<CreateUserPostTagAdminPayload> CreateUserPostTagAsync(
            [Service] IUserPostTagMutationService mutationService,
            [Service] IUserPostTagWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<CreateUserPostTagAdminInput> inputAdminValidator,
            CreateUserPostTagAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateUserPostTagAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateUserPostTagAdminInput, CreateUserPostTagDto>(input);
            var payload = await mutationService.CreateAsync<CreateUserPostTagAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendUserPostTagEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateUserPostTagAdminPayload> UpdateUserPostTagAsync(
            [Service] IUserPostTagMutationService mutationService,
            [Service] IUserPostTagWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<UpdateUserPostTagAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateUserPostTagAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateUserPostTagAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateUserPostTagAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateUserPostTagAdminInput, UpdateUserPostTagDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateUserPostTagAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendUserPostTagEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteUserPostTagAdminPayload> DeleteUserPostTagAsync(
            [Service] IUserPostTagMutationService mutationService,
            [Service] IUserPostTagWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var payload = await mutationService.DeleteAsync<DeleteUserPostTagAdminPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(UserPostTagAdminSubscription.OnUserPostTagCreated),
                        UserPostTagCreatedAdminEvent.From<UserPostTagCreatedAdminEvent>(result, userId, now));
                    break;
                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(UserPostTagAdminSubscription.OnUserPostTagUpdated),
                        UserPostTagUpdatedAdminEvent.From<UserPostTagUpdatedAdminEvent>(result, userId, now, modifiedFields ?? []));
                    break;
                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(UserPostTagAdminSubscription.OnUserPostTagDeleted),
                        UserPostTagDeletedAdminEvent.From<UserPostTagDeletedAdminEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(UserPostTagAdminSubscription.OnUserPostTagChanged),
                UserPostTagChangedAdminEvent.From<UserPostTagChangedAdminEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
