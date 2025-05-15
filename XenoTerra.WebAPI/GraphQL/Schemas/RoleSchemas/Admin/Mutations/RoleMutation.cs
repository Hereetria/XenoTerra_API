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
    public class RoleMutation
    {
        public async Task<CreateRolePayload> CreateRoleAsync(
            [Service] IRoleMutationService mutationService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateRoleInput> inputValidator,
            CreateRoleInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateRoleInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateRoleInput, CreateRoleDto>(input);
            var payload = await mutationService.CreateAsync(createDto);

            if (payload.IsSuccess())
                await SendRoleEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateRolePayload> UpdateRoleAsync(
            [Service] IRoleMutationService mutationService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateRoleInput> inputValidator,
            IResolverContext context,
            UpdateRoleInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateRoleInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateRoleInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateRoleInput, UpdateRoleDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync(updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendRoleEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteRolePayload> DeleteRoleAsync(
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
                    await sender.SendAsync(nameof(RoleSubscription.OnRoleCreated),
                        RoleCreatedEvent.From<RoleCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(RoleSubscription.OnRoleUpdated),
                        RoleUpdatedEvent.From<RoleUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(RoleSubscription.OnRoleDeleted),
                        RoleDeletedEvent.From<RoleDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(RoleSubscription.OnRoleChanged),
                RoleChangedEvent.From<RoleChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }

}