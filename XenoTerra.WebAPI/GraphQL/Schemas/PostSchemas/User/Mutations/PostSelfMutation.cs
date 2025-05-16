using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.PostService;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.PostMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Mutations
{
    public class PostSelfMutation
    {
        public async Task<CreatePostSelfPayload> CreatePostAsync(
            [Service] IPostMutationService mutationService,
            [Service] IPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreatePostSelfInput> inputSelfValidator,
            CreatePostSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreatePostSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreatePostSelfInput, CreatePostDto>(input);
            var payload = await mutationService.CreateAsync<CreatePostSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendPostEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdatePostSelfPayload> UpdatePostAsync(
            [Service] IPostMutationService mutationService,
            [Service] IPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdatePostSelfInput> inputSelfValidator,
            IResolverContext context,
            UpdatePostSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdatePostSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdatePostSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdatePostSelfInput, UpdatePostDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdatePostSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendPostEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeletePostSelfPayload> DeletePostAsync(
            [Service] IPostMutationService mutationService,
            [Service] IPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeletePostSelfPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(PostSelfSubscription.OnPostCreated),
                        PostCreatedSelfEvent.From<PostCreatedSelfEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(PostSelfSubscription.OnPostUpdated),
                        PostUpdatedSelfEvent.From<PostUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(PostSelfSubscription.OnPostDeleted),
                        PostDeletedSelfEvent.From<PostDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(PostSelfSubscription.OnPostChanged),
                PostChangedSelfEvent.From<PostChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
