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
    public class HighlightSelfMutation
    {
        public async Task<CreateHighlightSelfPayload> CreateHighlightAsync(
            [Service] IHighlightMutationService mutationService,
            [Service] IHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreateHighlightSelfInput> inputSelfValidator,
            CreateHighlightSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateHighlightSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateHighlightSelfInput, CreateHighlightDto>(input);
            var payload = await mutationService.CreateAsync<CreateHighlightSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendHighlightEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateHighlightSelfPayload> UpdateHighlightAsync(
            [Service] IHighlightMutationService mutationService,
            [Service] IHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateHighlightSelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateHighlightSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateHighlightSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateHighlightSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateHighlightSelfInput, UpdateHighlightDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateHighlightSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendHighlightEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteHighlightSelfPayload> DeleteHighlightAsync(
            [Service] IHighlightMutationService mutationService,
            [Service] IHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteHighlightSelfPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(HighlightSelfSubscription.OnHighlightCreated),
                        HighlightCreatedSelfEvent.From<HighlightCreatedSelfEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(HighlightSelfSubscription.OnHighlightUpdated),
                        HighlightUpdatedSelfEvent.From<HighlightUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(HighlightSelfSubscription.OnHighlightDeleted),
                        HighlightDeletedSelfEvent.From<HighlightDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(HighlightSelfSubscription.OnHighlightChanged),
                HighlightChangedSelfEvent.From<HighlightChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
