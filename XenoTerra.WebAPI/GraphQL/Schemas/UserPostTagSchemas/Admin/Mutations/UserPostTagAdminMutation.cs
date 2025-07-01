using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.UserPostTagMutationServices;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserPostTagServices.Write.Admin;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class UserPostTagAdminMutation
    {
        public async Task<CreateUserPostTagAdminPayload> CreateUserPostTagAsync(
            [Service] IUserPostTagAdminMutationService mutationService,
            [Service] IUserPostTagAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateUserPostTagAdminInput> inputAdminValidator,
            CreateUserPostTagAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateUserPostTagAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateUserPostTagAdminInput, CreateUserPostTagAdminDto>(input);
            var payload = await mutationService.CreateAsync<CreateUserPostTagAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendUserPostTagEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateUserPostTagAdminPayload> UpdateUserPostTagAsync(
            [Service] IUserPostTagAdminMutationService mutationService,
            [Service] IUserPostTagAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateUserPostTagAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateUserPostTagAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateUserPostTagAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateUserPostTagAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateUserPostTagAdminInput, UpdateUserPostTagAdminDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateUserPostTagAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendUserPostTagEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteUserPostTagAdminPayload> DeleteUserPostTagAsync(
            [Service] IUserPostTagAdminMutationService mutationService,
            [Service] IUserPostTagAdminWriteService writeService,
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
            ResultUserPostTagAdminDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(UserPostTagAdminSubscription.OnUserPostTagAdminCreated),
                        UserPostTagAdminCreatedEvent.From<UserPostTagAdminCreatedEvent>(result, userId, now));
                    break;
                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(UserPostTagAdminSubscription.OnUserPostTagAdminUpdated),
                        UserPostTagAdminUpdatedEvent.From<UserPostTagAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;
                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(UserPostTagAdminSubscription.OnUserPostTagAdminDeleted),
                        UserPostTagAdminDeletedEvent.From<UserPostTagAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(UserPostTagAdminSubscription.OnUserPostTagAdminChanged),
                UserPostTagAdminChangedEvent.From<UserPostTagAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
