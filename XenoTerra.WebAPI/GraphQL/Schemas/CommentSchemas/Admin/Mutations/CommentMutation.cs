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
    public class CommentMutation
    {
        public async Task<CreateCommentPayload> CreateCommentAsync(
            [Service] ICommentMutationService mutationService,
            [Service] ICommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateCommentInput> inputValidator,
            CreateCommentInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateCommentInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateCommentInput, CreateCommentDto>(input);
            var payload = await mutationService.CreateAsync<CreateCommentPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendCommentEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateCommentPayload> UpdateCommentAsync(
            [Service] ICommentMutationService mutationService,
            [Service] ICommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateCommentInput> inputValidator,
            IResolverContext context,
            UpdateCommentInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateCommentInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateCommentInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateCommentInput, UpdateCommentDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateCommentPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendCommentEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteCommentPayload> DeleteCommentAsync(
            [Service] ICommentMutationService mutationService,
            [Service] ICommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteCommentPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(CommentSubscription.OnCommentCreated),
                        CommentCreatedEvent.From<CommentCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(CommentSubscription.OnCommentUpdated),
                        CommentUpdatedEvent.From<CommentUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(CommentSubscription.OnCommentDeleted),
                        CommentDeletedEvent.From<CommentDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(CommentSubscription.OnCommentChanged),
                CommentChangedEvent.From<CommentChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
