using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.BussinessLogicLayer.Services.Entity.AppUserServices;
using XenoTerra.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Mutations.Inputs;
using XenoTerra.BussinessLogicLayer.Services.Entity.FollowServices.Write.Own;
using XenoTerra.BussinessLogicLayer.Services.Entity.FollowServices.Read;
using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Own;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.FollowMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class FollowOwnMutation
    {
        public async Task<CreateFollowOwnPayload> CreateOwnFollowAsync(
            [Service] IFollowOwnMutationService mutationService,
            [Service] IFollowOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateFollowOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            [Service] AppDbContext dbContext,
            CreateFollowOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateFollowOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var createDto = DtoMapperHelper.MapInputToDto<CreateFollowOwnInput, CreateFollowOwnDto>(input);
            createDto.FollowerId = currentUserId;

            createDto.IsPending = await IsFollowingUserPrivateAsync(dbContext, input.FollowingId);

            var payload = await mutationService.CreateAsync<CreateFollowOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendFollowEventAsync(eventSender, ChangedEventType.Created, payload.Result, currentUserId);

            return payload;
        }

        public async Task<UpdateFollowOwnPayload> UpdateOwnFollowAsync(
            [Service] IFollowOwnMutationService mutationService,
            [Service] IFollowOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateFollowOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateFollowOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateFollowOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateFollowOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateFollowOwnInput, UpdateFollowOwnDto>(input, modifiedFields);
            updateDto.FollowerId = userId;

            var payload = await mutationService.UpdateAsync<UpdateFollowOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendFollowEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteFollowOwnPayload> DeleteOwnFollowAsync(
            [Service] IFollowOwnMutationService mutationService,
            [Service] IFollowReadService readService,
            [Service] IFollowOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var follow = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.FollowerId
            );

            if (follow.FollowerId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteFollowOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendFollowEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }

        private static async Task<bool> IsFollowingUserPrivateAsync(AppDbContext dbContext, string? followingId)
        {
            if (!Guid.TryParse(followingId, out var parsedId))
                return false;

            var user = await dbContext.Users
                .Include(u => u.UserSetting)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == parsedId);

            if (user is null)
            {
                throw GraphQLExceptionFactory.Create(
                    "User not found",
                    [$"Cannot find user with id {parsedId}"],
                    "USER_NOT_FOUND"
                );
            }

            return user.UserSetting?.IsPrivate ?? false;
        }


        private async Task SendFollowEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultFollowOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(FollowOwnSubscription.OnFollowOwnCreated),
                        FollowOwnCreatedEvent.From<FollowOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(FollowOwnSubscription.OnFollowOwnUpdated),
                        FollowOwnUpdatedEvent.From<FollowOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(FollowOwnSubscription.OnFollowOwnDeleted),
                        FollowOwnDeletedEvent.From<FollowOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(FollowOwnSubscription.OnFollowOwnChanged),
                FollowOwnChangedEvent.From<FollowOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

