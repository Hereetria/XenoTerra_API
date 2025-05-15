using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.HighlightService;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.HighlightDtos;
using XenoTerra.WebAPI.Services.Mutations.Entity.HighlightMutationServices;
using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Mutations
{
    public class HighlightMutation
    {
        public async Task<CreateHighlightPayload> CreateHighlightAsync(
            [Service] IHighlightMutationService mutationService,
            [Service] IHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateHighlightInput> inputValidator,
            CreateHighlightInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateHighlightInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateHighlightInput, CreateHighlightDto>(input);
            var payload = await mutationService.CreateAsync<CreateHighlightPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendHighlightEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateHighlightPayload> UpdateHighlightAsync(
            [Service] IHighlightMutationService mutationService,
            [Service] IHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateHighlightInput> inputValidator,
            IResolverContext context,
            UpdateHighlightInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateHighlightInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateHighlightInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateHighlightInput, UpdateHighlightDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateHighlightPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendHighlightEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteHighlightPayload> DeleteHighlightAsync(
            [Service] IHighlightMutationService mutationService,
            [Service] IHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteHighlightPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendHighlightEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendHighlightEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultHighlightDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(HighlightSubscription.OnHighlightCreated),
                        HighlightCreatedEvent.From<HighlightCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(HighlightSubscription.OnHighlightUpdated),
                        HighlightUpdatedEvent.From<HighlightUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(HighlightSubscription.OnHighlightDeleted),
                        HighlightDeletedEvent.From<HighlightDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(HighlightSubscription.OnHighlightChanged),
                HighlightChangedEvent.From<HighlightChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
