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
    public class CommentSelfMutation
    {
        public async Task<CreateCommentSelfPayload> CreateCommentAsync(
            [Service] ICommentMutationService mutationService,
            [Service] ICommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreateCommentSelfInput> inputSelfValidator,
            CreateCommentSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateCommentSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateCommentSelfInput, CreateCommentDto>(input);
            var payload = await mutationService.CreateAsync<CreateCommentSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendCommentEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateCommentSelfPayload> UpdateCommentAsync(
            [Service] ICommentMutationService mutationService,
            [Service] ICommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateCommentSelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateCommentSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateCommentSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateCommentSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateCommentSelfInput, UpdateCommentDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateCommentSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendCommentEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteCommentSelfPayload> DeleteCommentAsync(
            [Service] ICommentMutationService mutationService,
            [Service] ICommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteCommentSelfPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(CommentSelfSubscription.OnCommentCreated),
                        CommentCreatedSelfEvent.From<CommentCreatedSelfEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(CommentSelfSubscription.OnCommentUpdated),
                        CommentUpdatedSelfEvent.From<CommentUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(CommentSelfSubscription.OnCommentDeleted),
                        CommentDeletedSelfEvent.From<CommentDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(CommentSelfSubscription.OnCommentChanged),
                CommentChangedSelfEvent.From<CommentChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
