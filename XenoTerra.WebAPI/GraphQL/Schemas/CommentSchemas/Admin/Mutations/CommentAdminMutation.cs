using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.CommentMutationServices;
using XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Admin;
using XenoTerra.BussinessLogicLayer.Services.Entity.CommentServices.Write.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class CommentAdminMutation
    {
        public async Task<CreateCommentAdminPayload> CreateCommentAsync(
            [Service] ICommentAdminMutationService mutationService,
            [Service] ICommentAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateCommentAdminInput> inputAdminValidator,
            CreateCommentAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateCommentAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateCommentAdminInput, CreateCommentAdminDto>(input);
            var payload = await mutationService.CreateAsync<CreateCommentAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendCommentEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateCommentAdminPayload> UpdateCommentAsync(
            [Service] ICommentAdminMutationService mutationService,
            [Service] ICommentAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateCommentAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateCommentAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateCommentAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateCommentAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateCommentAdminInput, UpdateCommentAdminDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateCommentAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendCommentEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteCommentAdminPayload> DeleteCommentAsync(
            [Service] ICommentAdminMutationService mutationService,
            [Service] ICommentAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteCommentAdminPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendCommentEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendCommentEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultCommentAdminDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(CommentAdminSubscription.OnCommentAdminCreated),
                        CommentAdminCreatedEvent.From<CommentAdminCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(CommentAdminSubscription.OnCommentAdminUpdated),
                        CommentAdminUpdatedEvent.From<CommentAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(CommentAdminSubscription.OnCommentAdminDeleted),
                        CommentAdminDeletedEvent.From<CommentAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(CommentAdminSubscription.OnCommentAdminChanged),
                CommentAdminChangedEvent.From<CommentAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
