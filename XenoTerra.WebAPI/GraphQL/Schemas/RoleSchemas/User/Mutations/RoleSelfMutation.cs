using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.RoleService;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.RoleMutationServices;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Mutations
{
    public class RoleSelfMutation
    {
        public async Task<CreateRoleSelfPayload> CreateRoleAsync(
            [Service] IRoleMutationService mutationService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreateRoleSelfInput> inputSelfValidator,
            CreateRoleSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateRoleSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateRoleSelfInput, CreateRoleDto>(input);
            var payload = await mutationService.CreateAsync(createDto);

            if (payload.IsSuccess())
                await SendRoleEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateRoleSelfPayload> UpdateRoleAsync(
            [Service] IRoleMutationService mutationService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateRoleSelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateRoleSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateRoleSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateRoleSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateRoleSelfInput, UpdateRoleDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync(updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendRoleEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteRoleSelfPayload> DeleteRoleAsync(
            [Service] IRoleMutationService mutationService,
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
                    await sender.SendAsync(nameof(RoleSelfSubscription.OnRoleCreated),
                        RoleCreatedSelfEvent.From<RoleCreatedSelfEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(RoleSelfSubscription.OnRoleUpdated),
                        RoleUpdatedSelfEvent.From<RoleUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(RoleSelfSubscription.OnRoleDeleted),
                        RoleDeletedSelfEvent.From<RoleDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(RoleSelfSubscription.OnRoleChanged),
                RoleChangedSelfEvent.From<RoleChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }

}