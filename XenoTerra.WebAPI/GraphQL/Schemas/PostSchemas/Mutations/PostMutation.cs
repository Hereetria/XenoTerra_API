using FluentValidation;
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
            [Service] IValidator<CreatePostInput> inputValidator,
            CreatePostInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreatePostInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreatePostInput, CreatePostDto>(input);
            var payload = await mutationService.CreateAsync<CreatePostPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendPostEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdatePostPayload> UpdatePostAsync(
            [Service] IPostMutationService mutationService,
            [Service] IPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdatePostInput> inputValidator,
            IResolverContext context,
            UpdatePostInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdatePostInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdatePostInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdatePostInput, UpdatePostDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdatePostPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendPostEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeletePostPayload> DeletePostAsync(
            [Service] IPostMutationService mutationService,
            [Service] IPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeletePostPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendPostEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendPostEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultPostDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(PostSubscription.OnPostCreated),
                        PostCreatedEvent.From<PostCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(PostSubscription.OnPostUpdated),
                        PostUpdatedEvent.From<PostUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(PostSubscription.OnPostDeleted),
                        PostDeletedEvent.From<PostDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(PostSubscription.OnPostChanged),
                PostChangedEvent.From<PostChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
