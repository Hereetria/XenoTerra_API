using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.CommentLikeMutationServices;
using XenoTerra.BussinessLogicLayer.Services.Entity.CommentLikeServices.Write.Admin;
using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class CommentLikeAdminMutation
    {
        public async Task<CreateCommentLikeAdminPayload> CreateCommentLikeAsync(
            [Service] ICommentLikeAdminMutationService mutationService,
            [Service] ICommentLikeAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateCommentLikeAdminInput> inputAdminValidator,
            CreateCommentLikeAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateCommentLikeAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateCommentLikeAdminInput, CreateCommentLikeAdminDto>(input);
            var payload = await mutationService.CreateAsync<CreateCommentLikeAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendCommentLikeEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateCommentLikeAdminPayload> UpdateCommentLikeAsync(
            [Service] ICommentLikeAdminMutationService mutationService,
            [Service] ICommentLikeAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateCommentLikeAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateCommentLikeAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateCommentLikeAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateCommentLikeAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateCommentLikeAdminInput, UpdateCommentLikeAdminDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateCommentLikeAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendCommentLikeEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteCommentLikeAdminPayload> DeleteCommentLikeAsync(
            [Service] ICommentLikeAdminMutationService mutationService,
            [Service] ICommentLikeAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteCommentLikeAdminPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendCommentLikeEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendCommentLikeEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultCommentLikeAdminDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(CommentLikeAdminSubscription.OnCommentLikeAdminCreated),
                        CommentLikeAdminCreatedEvent.From<CommentLikeAdminCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(CommentLikeAdminSubscription.OnCommentLikeAdminUpdated),
                        CommentLikeAdminUpdatedEvent.From<CommentLikeAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(CommentLikeAdminSubscription.OnCommentLikeAdminDeleted),
                        CommentLikeAdminDeletedEvent.From<CommentLikeAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(CommentLikeAdminSubscription.OnCommentLikeAdminChanged),
                CommentLikeAdminChangedEvent.From<CommentLikeAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
