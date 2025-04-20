using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.PostService;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.PostMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.PostMutations
{
    public class PostMutation
    {
        public async Task<CreatePostPayload> CreatePostAsync(
            [Service] IPostMutationService mutationService,
            [Service] IPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            CreatePostInput? input)
        {
            if (!InputValidator.ValidateInputFields<Post, CreatePostInput, ResultPostDto, CreatePostPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreatePostInput, CreatePostDto>(input);
            var payload = await mutationService.CreateAsync<CreatePostPayload>(writeService, createDto);

            await SendPostCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdatePostPayload> UpdatePostAsync(
            [Service] IPostMutationService mutationService,
            [Service] IPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdatePostInput? input)
        {
            if (!InputValidator.ValidateInputFields<Post, UpdatePostInput, ResultPostDto, UpdatePostPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdatePostInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdatePostInput, UpdatePostDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdatePostPayload>(writeService, updateDto, modifiedFields);

            await SendPostUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeletePostPayload> DeletePostAsync(
            [Service] IPostMutationService mutationService,
            [Service] IPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<Post, ResultPostDto, DeletePostPayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeletePostPayload>(writeService, parsedKey);

            await SendPostDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendPostCreatedEvents(ITopicEventSender sender, ResultPostDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(PostSubscription.OnPostCreated),
                PostCreatedEvent.From<PostCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(PostSubscription.OnPostChanged),
                PostChangedEvent.From<PostChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendPostUpdatedEvents(ITopicEventSender sender, ResultPostDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(PostSubscription.OnPostUpdated),
                PostUpdatedEvent.From<PostUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(PostSubscription.OnPostChanged),
                PostChangedEvent.From<PostChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendPostDeletedEvents(ITopicEventSender sender, ResultPostDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(PostSubscription.OnPostDeleted),
                PostDeletedEvent.From<PostDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(PostSubscription.OnPostChanged),
                PostChangedEvent.From<PostChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}
