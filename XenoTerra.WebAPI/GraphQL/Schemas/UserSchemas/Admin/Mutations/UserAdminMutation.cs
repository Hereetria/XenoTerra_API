using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.UserMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class UserAdminMutation
    {
        //public async Task<CreateUserAdminPayload> CreateUserAsync(
        //    [Service] IUserAdminMutationService mutationService,
        //    [Service] ITopicEventSender eventSender,
        //    [Service] IValidator<CreateUserAdminInput> inputAdminValidator,
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
            [Service] IUserAdminMutationService mutationService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateUserAdminInput> inputAdminValidator,
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
            [Service] IUserAdminMutationService mutationService,
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
            ResultUserPrivateDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(UserAdminSubscription.OnUserAdminCreated),
                        UserAdminCreatedEvent.From<UserAdminCreatedEvent>(result, userId, now));
                    break;
                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(UserAdminSubscription.OnUserAdminUpdated),
                        UserAdminUpdatedEvent.From<UserAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;
                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(UserAdminSubscription.OnUserAdminDeleted),
                        UserAdminDeletedEvent.From<UserAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(UserAdminSubscription.OnUserAdminChanged),
                UserAdminChangedEvent.From<UserAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
