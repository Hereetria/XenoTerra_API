using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.WebAPI.Helpers;
using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.RoleMutationServices;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class RoleAdminMutation
    {
        public async Task<CreateRoleAdminPayload> CreateRoleAsync(
            [Service] IRoleAdminMutationService mutationService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateRoleAdminInput> inputAdminValidator,
            CreateRoleAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateRoleAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateRoleAdminInput, CreateRoleDto>(input);
            var payload = await mutationService.CreateAsync(createDto);

            if (payload.IsSuccess())
                await SendRoleEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateRoleAdminPayload> UpdateRoleAsync(
            [Service] IRoleAdminMutationService mutationService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateRoleAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateRoleAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateRoleAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateRoleAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateRoleAdminInput, UpdateRoleDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync(updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendRoleEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteRoleAdminPayload> DeleteRoleAsync(
            [Service] IRoleAdminMutationService mutationService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync(parsedKey);

            if (payload.IsSuccess())
                await SendRoleEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendRoleEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultRoleDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(RoleAdminSubscription.OnRoleAdminCreated),
                        RoleAdminCreatedEvent.From<RoleAdminCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(RoleAdminSubscription.OnRoleAdminUpdated),
                        RoleAdminUpdatedEvent.From<RoleAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(RoleAdminSubscription.OnRoleAdminDeleted),
                        RoleAdminDeletedEvent.From<RoleAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(RoleAdminSubscription.OnRoleAdminChanged),
                RoleAdminChangedEvent.From<RoleAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }

}