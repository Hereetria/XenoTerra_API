using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.CommentServices;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.CommentMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class CommentSelfMutation
    {
        public async Task<CreateCommentSelfPayload> CreateMyCommentAsync(
            [Service] ICommentSelfMutationService mutationService,
            [Service] ICommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateCommentSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateCommentSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateCommentSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateCommentSelfInput, CreateCommentDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateCommentSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendCommentEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateCommentSelfPayload> UpdateMyCommentAsync(
            [Service] ICommentSelfMutationService mutationService,
            [Service] ICommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateCommentSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateCommentSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateCommentSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateCommentSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateCommentSelfInput, UpdateCommentDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateCommentSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendCommentEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteCommentSelfPayload> DeleteMyCommentAsync(
            [Service] ICommentSelfMutationService mutationService,
            [Service] ICommentReadService readService,
            [Service] ICommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var comment = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.UserId
            );

            if (comment.UserId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteCommentSelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendCommentEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendCommentEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultCommentDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(CommentSelfSubscription.OnCommentSelfCreated),
                        CommentSelfCreatedEvent.From<CommentSelfCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(CommentSelfSubscription.OnCommentSelfUpdated),
                        CommentSelfUpdatedEvent.From<CommentSelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(CommentSelfSubscription.OnCommentSelfDeleted),
                        CommentSelfDeletedEvent.From<CommentSelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(CommentSelfSubscription.OnCommentSelfChanged),
                CommentSelfChangedEvent.From<CommentSelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}