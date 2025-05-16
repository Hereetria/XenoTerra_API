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
    public class LikeSelfMutation
    {
        public async Task<CreateLikeSelfPayload> CreateLikeAsync(
            [Service] ILikeMutationService mutationService,
            [Service] ILikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreateLikeSelfInput> inputSelfValidator,
            CreateLikeSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateLikeSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateLikeSelfInput, CreateLikeDto>(input);
            var payload = await mutationService.CreateAsync<CreateLikeSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateLikeSelfPayload> UpdateLikeAsync(
            [Service] ILikeMutationService mutationService,
            [Service] ILikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateLikeSelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateLikeSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateLikeSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateLikeSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateLikeSelfInput, UpdateLikeDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateLikeSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteLikeSelfPayload> DeleteLikeAsync(
            [Service] ILikeMutationService mutationService,
            [Service] ILikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteLikeSelfPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(LikeSelfSubscription.OnLikeCreated),
                        LikeCreatedSelfEvent.From<LikeCreatedSelfEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(LikeSelfSubscription.OnLikeUpdated),
                        LikeUpdatedSelfEvent.From<LikeUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(LikeSelfSubscription.OnLikeDeleted),
                        LikeDeletedSelfEvent.From<LikeDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(LikeSelfSubscription.OnLikeChanged),
                LikeChangedSelfEvent.From<LikeChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
