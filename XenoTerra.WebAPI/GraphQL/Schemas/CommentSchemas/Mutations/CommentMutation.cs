using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.CommentService;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.CommentMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Mutations
{
    public class CommentMutation
    {
        public async Task<CreateCommentPayload> CreateCommentAsync(
            [Service] ICommentMutationService mutationService,
            [Service] ICommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            CreateCommentInput? input)
        {
            if (!InputValidator.ValidateInputFields<Comment, CreateCommentInput, ResultCommentDto, CreateCommentPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateCommentInput, CreateCommentDto>(input);
            var payload = await mutationService.CreateAsync<CreateCommentPayload>(writeService, createDto);

            await SendCommentCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateCommentPayload> UpdateCommentAsync(
            [Service] ICommentMutationService mutationService,
            [Service] ICommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateCommentInput? input)
        {
            if (!InputValidator.ValidateInputFields<Comment, UpdateCommentInput, ResultCommentDto, UpdateCommentPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateCommentInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateCommentInput, UpdateCommentDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateCommentPayload>(writeService, updateDto, modifiedFields);

            await SendCommentUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteCommentPayload> DeleteCommentAsync(
            [Service] ICommentMutationService mutationService,
            [Service] ICommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<Comment, ResultCommentDto, DeleteCommentPayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteCommentPayload>(writeService, parsedKey);

            await SendCommentDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendCommentCreatedEvents(ITopicEventSender sender, ResultCommentDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(CommentSubscription.OnCommentCreated),
                CommentCreatedEvent.From<CommentCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(CommentSubscription.OnCommentChanged),
                CommentChangedEvent.From<CommentChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendCommentUpdatedEvents(ITopicEventSender sender, ResultCommentDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(CommentSubscription.OnCommentUpdated),
                CommentUpdatedEvent.From<CommentUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(CommentSubscription.OnCommentChanged),
                CommentChangedEvent.From<CommentChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendCommentDeletedEvents(ITopicEventSender sender, ResultCommentDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(CommentSubscription.OnCommentDeleted),
                CommentDeletedEvent.From<CommentDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(CommentSubscription.OnCommentChanged),
                CommentChangedEvent.From<CommentChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}
