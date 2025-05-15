using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.LikeService;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.LikeMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Mutations
{
    public class LikeMutation
    {
        public async Task<CreateLikePayload> CreateLikeAsync(
            [Service] ILikeMutationService mutationService,
            [Service] ILikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateLikeInput> inputValidator,
            CreateLikeInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateLikeInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateLikeInput, CreateLikeDto>(input);
            var payload = await mutationService.CreateAsync<CreateLikePayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateLikePayload> UpdateLikeAsync(
            [Service] ILikeMutationService mutationService,
            [Service] ILikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateLikeInput> inputValidator,
            IResolverContext context,
            UpdateLikeInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateLikeInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateLikeInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateLikeInput, UpdateLikeDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateLikePayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteLikePayload> DeleteLikeAsync(
            [Service] ILikeMutationService mutationService,
            [Service] ILikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteLikePayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendLikeEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultLikeDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(LikeSubscription.OnLikeCreated),
                        LikeCreatedEvent.From<LikeCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(LikeSubscription.OnLikeUpdated),
                        LikeUpdatedEvent.From<LikeUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(LikeSubscription.OnLikeDeleted),
                        LikeDeletedEvent.From<LikeDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(LikeSubscription.OnLikeChanged),
                LikeChangedEvent.From<LikeChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
