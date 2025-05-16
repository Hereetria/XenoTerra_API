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
    public class HighlightAdminMutation
    {
        public async Task<CreateHighlightAdminPayload> CreateHighlightAsync(
            [Service] IHighlightMutationService mutationService,
            [Service] IHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<CreateHighlightAdminInput> inputAdminValidator,
            CreateHighlightAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateHighlightAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateHighlightAdminInput, CreateHighlightDto>(input);
            var payload = await mutationService.CreateAsync<CreateHighlightAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendHighlightEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateHighlightAdminPayload> UpdateHighlightAsync(
            [Service] IHighlightMutationService mutationService,
            [Service] IHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<UpdateHighlightAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateHighlightAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateHighlightAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateHighlightAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateHighlightAdminInput, UpdateHighlightDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateHighlightAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendHighlightEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteHighlightAdminPayload> DeleteHighlightAsync(
            [Service] IHighlightMutationService mutationService,
            [Service] IHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteHighlightAdminPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(HighlightAdminSubscription.OnHighlightCreated),
                        HighlightCreatedAdminEvent.From<HighlightCreatedAdminEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(HighlightAdminSubscription.OnHighlightUpdated),
                        HighlightUpdatedAdminEvent.From<HighlightUpdatedAdminEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(HighlightAdminSubscription.OnHighlightDeleted),
                        HighlightDeletedAdminEvent.From<HighlightDeletedAdminEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(HighlightAdminSubscription.OnHighlightChanged),
                HighlightChangedAdminEvent.From<HighlightChangedAdminEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
