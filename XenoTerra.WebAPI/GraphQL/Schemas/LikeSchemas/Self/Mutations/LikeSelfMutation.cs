using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.LikeServices;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.LikeMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class LikeSelfMutation
    {
        public async Task<CreateLikeSelfPayload> CreateMyLikeAsync(
            [Service] ILikeSelfMutationService mutationService,
            [Service] ILikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateLikeSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateLikeSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateLikeSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateLikeSelfInput, CreateLikeDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateLikeSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateLikeSelfPayload> UpdateMyLikeAsync(
            [Service] ILikeSelfMutationService mutationService,
            [Service] ILikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateLikeSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateLikeSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateLikeSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateLikeSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateLikeSelfInput, UpdateLikeDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateLikeSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteLikeSelfPayload> DeleteMyLikeAsync(
            [Service] ILikeSelfMutationService mutationService,
            [Service] ILikeReadService readService,
            [Service] ILikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var like = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.UserId
            );

            if (like.UserId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteLikeSelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendLikeEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultLikeDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(LikeSelfSubscription.OnLikeSelfCreated),
                        LikeSelfCreatedEvent.From<LikeSelfCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(LikeSelfSubscription.OnLikeSelfUpdated),
                        LikeSelfUpdatedEvent.From<LikeSelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(LikeSelfSubscription.OnLikeSelfDeleted),
                        LikeSelfDeletedEvent.From<LikeSelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(LikeSelfSubscription.OnLikeSelfChanged),
                LikeSelfChangedEvent.From<LikeSelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

