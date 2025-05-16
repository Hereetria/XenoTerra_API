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
    public class PostAdminMutation
    {
        public async Task<CreatePostAdminPayload> CreatePostAsync(
            [Service] IPostMutationService mutationService,
            [Service] IPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<CreatePostAdminInput> inputAdminValidator,
            CreatePostAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreatePostAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreatePostAdminInput, CreatePostDto>(input);
            var payload = await mutationService.CreateAsync<CreatePostAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendPostEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdatePostAdminPayload> UpdatePostAsync(
            [Service] IPostMutationService mutationService,
            [Service] IPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<UpdatePostAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdatePostAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdatePostAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdatePostAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdatePostAdminInput, UpdatePostDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdatePostAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendPostEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeletePostAdminPayload> DeletePostAsync(
            [Service] IPostMutationService mutationService,
            [Service] IPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeletePostAdminPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(PostAdminSubscription.OnPostCreated),
                        PostCreatedAdminEvent.From<PostCreatedAdminEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(PostAdminSubscription.OnPostUpdated),
                        PostUpdatedAdminEvent.From<PostUpdatedAdminEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(PostAdminSubscription.OnPostDeleted),
                        PostDeletedAdminEvent.From<PostDeletedAdminEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(PostAdminSubscription.OnPostChanged),
                PostChangedAdminEvent.From<PostChangedAdminEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
