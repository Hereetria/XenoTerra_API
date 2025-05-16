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
    public class LikeAdminMutation
    {
        public async Task<CreateLikeAdminPayload> CreateLikeAsync(
            [Service] ILikeMutationService mutationService,
            [Service] ILikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<CreateLikeAdminInput> inputAdminValidator,
            CreateLikeAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateLikeAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateLikeAdminInput, CreateLikeDto>(input);
            var payload = await mutationService.CreateAsync<CreateLikeAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateLikeAdminPayload> UpdateLikeAsync(
            [Service] ILikeMutationService mutationService,
            [Service] ILikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<UpdateLikeAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateLikeAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateLikeAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateLikeAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateLikeAdminInput, UpdateLikeDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateLikeAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteLikeAdminPayload> DeleteLikeAsync(
            [Service] ILikeMutationService mutationService,
            [Service] ILikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteLikeAdminPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(LikeAdminSubscription.OnLikeCreated),
                        LikeCreatedAdminEvent.From<LikeCreatedAdminEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(LikeAdminSubscription.OnLikeUpdated),
                        LikeUpdatedAdminEvent.From<LikeUpdatedAdminEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(LikeAdminSubscription.OnLikeDeleted),
                        LikeDeletedAdminEvent.From<LikeDeletedAdminEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(LikeAdminSubscription.OnLikeChanged),
                LikeChangedAdminEvent.From<LikeChangedAdminEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
