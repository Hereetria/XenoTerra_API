using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.RoleService;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.RoleMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Mutations
{
    public class RoleMutation
    {
        public async Task<CreateRolePayload> CreateRoleAsync(
            [Service] IRoleMutationService mutationService,
            [Service] IRoleWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            CreateRoleInput? input)
        {
            if (!InputValidator.ValidateInputFields<Role, CreateRoleInput, ResultRoleDto, CreateRolePayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateRoleInput, CreateRoleDto>(input);
            var payload = await mutationService.CreateAsync<CreateRolePayload>(writeService, createDto);

            await SendRoleCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateRolePayload> UpdateRoleAsync(
            [Service] IRoleMutationService mutationService,
            [Service] IRoleWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateRoleInput? input)
        {
            if (!InputValidator.ValidateInputFields<Role, UpdateRoleInput, ResultRoleDto, UpdateRolePayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateRoleInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateRoleInput, UpdateRoleDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateRolePayload>(writeService, updateDto, modifiedFields);

            await SendRoleUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteRolePayload> DeleteRoleAsync(
            [Service] IRoleMutationService mutationService,
            [Service] IRoleWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<Role, ResultRoleDto, DeleteRolePayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteRolePayload>(writeService, parsedKey);

            await SendRoleDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendRoleCreatedEvents(ITopicEventSender sender, ResultRoleDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(RoleSubscription.OnRoleCreated),
                RoleCreatedEvent.From<RoleCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(RoleSubscription.OnRoleChanged),
                RoleChangedEvent.From<RoleChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendRoleUpdatedEvents(ITopicEventSender sender, ResultRoleDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(RoleSubscription.OnRoleUpdated),
                RoleUpdatedEvent.From<RoleUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(RoleSubscription.OnRoleChanged),
                RoleChangedEvent.From<RoleChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendRoleDeletedEvents(ITopicEventSender sender, ResultRoleDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(RoleSubscription.OnRoleDeleted),
                RoleDeletedEvent.From<RoleDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(RoleSubscription.OnRoleChanged),
                RoleChangedEvent.From<RoleChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}