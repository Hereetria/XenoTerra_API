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
    public class RoleAdminMutation
    {
        public async Task<CreateRoleAdminPayload> CreateRoleAsync(
            [Service] IRoleMutationService mutationService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<CreateRoleAdminInput> inputAdminValidator,
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
            [Service] IRoleMutationService mutationService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<UpdateRoleAdminInput> inputAdminValidator,
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
                    await sender.SendAsync(nameof(RoleAdminSubscription.OnRoleCreated),
                        RoleCreatedAdminEvent.From<RoleCreatedAdminEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(RoleAdminSubscription.OnRoleUpdated),
                        RoleUpdatedAdminEvent.From<RoleUpdatedAdminEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(RoleAdminSubscription.OnRoleDeleted),
                        RoleDeletedAdminEvent.From<RoleDeletedAdminEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(RoleAdminSubscription.OnRoleChanged),
                RoleChangedAdminEvent.From<RoleChangedAdminEvent>(eventType, result, userId, now, modifiedFields));
        }
    }

}