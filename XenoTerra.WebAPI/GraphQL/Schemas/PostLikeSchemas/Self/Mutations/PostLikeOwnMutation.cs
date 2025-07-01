using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Mutations.Inputs;
using XenoTerra.BussinessLogicLayer.Services.Entity.PostLikeServices.Read;
using XenoTerra.BussinessLogicLayer.Services.Entity.PostLikeServices.Write.Own;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Own;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.PostLikeMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class PostLikeOwnMutation
    {
        public async Task<CreatePostLikeOwnPayload> CreateOwnPostLikeAsync(
            [Service] IPostLikeOwnMutationService mutationService,
            [Service] IPostLikeOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreatePostLikeOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreatePostLikeOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreatePostLikeOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreatePostLikeOwnInput, CreatePostLikeOwnDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreatePostLikeOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdatePostLikeOwnPayload> UpdateOwnPostLikeAsync(
            [Service] IPostLikeOwnMutationService mutationService,
            [Service] IPostLikeOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdatePostLikeOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdatePostLikeOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdatePostLikeOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdatePostLikeOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdatePostLikeOwnInput, UpdatePostLikeOwnDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var payload = await mutationService.UpdateAsync<UpdatePostLikeOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeletePostLikeOwnPayload> DeleteOwnPostLikeAsync(
            [Service] IPostLikeOwnMutationService mutationService,
            [Service] IPostLikeReadService readService,
            [Service] IPostLikeOwnWriteService writeService,
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

            var payload = await mutationService.DeleteAsync<DeletePostLikeOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendLikeEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultPostLikeOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(PostLikeOwnSubscription.OnPostLikeOwnCreated),
                        PostLikeOwnCreatedEvent.From<PostLikeOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(PostLikeOwnSubscription.OnPostLikeOwnUpdated),
                        PostLikeOwnUpdatedEvent.From<PostLikeOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(PostLikeOwnSubscription.OnPostLikeOwnDeleted),
                        PostLikeOwnDeletedEvent.From<PostLikeOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(PostLikeOwnSubscription.OnPostLikeOwnChanged),
                PostLikeOwnChangedEvent.From<PostLikeOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

