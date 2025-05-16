using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.CommentService;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.CommentMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations
{
    public class CommentAdminMutation
    {
        public async Task<CreateCommentAdminPayload> CreateCommentAsync(
            [Service] ICommentMutationService mutationService,
            [Service] ICommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<CreateCommentAdminInput> inputAdminValidator,
            CreateCommentAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateCommentAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateCommentAdminInput, CreateCommentDto>(input);
            var payload = await mutationService.CreateAsync<CreateCommentAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendCommentEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateCommentAdminPayload> UpdateCommentAsync(
            [Service] ICommentMutationService mutationService,
            [Service] ICommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<UpdateCommentAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateCommentAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateCommentAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateCommentAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateCommentAdminInput, UpdateCommentDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateCommentAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendCommentEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteCommentAdminPayload> DeleteCommentAsync(
            [Service] ICommentMutationService mutationService,
            [Service] ICommentWriteService writeService,
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
            ResultCommentDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(CommentAdminSubscription.OnCommentCreated),
                        CommentCreatedAdminEvent.From<CommentCreatedAdminEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(CommentAdminSubscription.OnCommentUpdated),
                        CommentUpdatedAdminEvent.From<CommentUpdatedAdminEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(CommentAdminSubscription.OnCommentDeleted),
                        CommentDeletedAdminEvent.From<CommentDeletedAdminEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(CommentAdminSubscription.OnCommentChanged),
                CommentChangedAdminEvent.From<CommentChangedAdminEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
