using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.HighlightService;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.HighlightDtos;
using XenoTerra.WebAPI.Services.Mutations.Entity.HighlightMutationServices;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Subscriptions;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Mutations
{
    public class HighlightMutation
    {
        public async Task<CreateHighlightPayload> CreateHighlightAsync(
            [Service] IHighlightMutationService mutationService,
            [Service] IHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            CreateHighlightInput? input)
        {
            if (!InputValidator.ValidateInputFields<Highlight, CreateHighlightInput, ResultHighlightDto, CreateHighlightPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateHighlightInput, CreateHighlightDto>(input);
            var payload = await mutationService.CreateAsync<CreateHighlightPayload>(writeService, createDto);

            await SendHighlightCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateHighlightPayload> UpdateHighlightAsync(
            [Service] IHighlightMutationService mutationService,
            [Service] IHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateHighlightInput? input)
        {
            if (!InputValidator.ValidateInputFields<Highlight, UpdateHighlightInput, ResultHighlightDto, UpdateHighlightPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateHighlightInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateHighlightInput, UpdateHighlightDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateHighlightPayload>(writeService, updateDto, modifiedFields);

            await SendHighlightUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteHighlightPayload> DeleteHighlightAsync(
            [Service] IHighlightMutationService mutationService,
            [Service] IHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<Highlight, ResultHighlightDto, DeleteHighlightPayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteHighlightPayload>(writeService, parsedKey);

            await SendHighlightDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendHighlightCreatedEvents(ITopicEventSender sender, ResultHighlightDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(HighlightSubscription.OnHighlightCreated),
                HighlightCreatedEvent.From<HighlightCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(HighlightSubscription.OnHighlightChanged),
                HighlightChangedEvent.From<HighlightChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendHighlightUpdatedEvents(ITopicEventSender sender, ResultHighlightDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(HighlightSubscription.OnHighlightUpdated),
                HighlightUpdatedEvent.From<HighlightUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(HighlightSubscription.OnHighlightChanged),
                HighlightChangedEvent.From<HighlightChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendHighlightDeletedEvents(ITopicEventSender sender, ResultHighlightDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(HighlightSubscription.OnHighlightDeleted),
                HighlightDeletedEvent.From<HighlightDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(HighlightSubscription.OnHighlightChanged),
                HighlightChangedEvent.From<HighlightChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}
