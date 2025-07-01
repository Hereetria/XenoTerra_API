using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.PostLikeMutationServices;
using XenoTerra.BussinessLogicLayer.Services.Entity.PostLikeServices.Write.Admin;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class PostLikeAdminMutation
    {
        public async Task<CreatePostLikeAdminPayload> CreatePostLikeAsync(
            [Service] IPostLikeAdminMutationService mutationService,
            [Service] IPostLikeAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreatePostLikeAdminInput> inputAdminValidator,
            CreatePostLikeAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreatePostLikeAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreatePostLikeAdminInput, CreatePostLikeAdminDto>(input);
            var payload = await mutationService.CreateAsync<CreatePostLikeAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendPostLikeEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdatePostLikeAdminPayload> UpdatePostLikeAsync(
            [Service] IPostLikeAdminMutationService mutationService,
            [Service] IPostLikeAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdatePostLikeAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdatePostLikeAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdatePostLikeAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdatePostLikeAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdatePostLikeAdminInput, UpdatePostLikeAdminDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdatePostLikeAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendPostLikeEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeletePostLikeAdminPayload> DeletePostLikeAsync(
            [Service] IPostLikeAdminMutationService mutationService,
            [Service] IPostLikeAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeletePostLikeAdminPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendPostLikeEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendPostLikeEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultPostLikeAdminDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(PostLikeAdminSubscription.OnPostLikeAdminCreated),
                        PostLikeAdminCreatedEvent.From<PostLikeAdminCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(PostLikeAdminSubscription.OnPostLikeAdminUpdated),
                        PostLikeAdminUpdatedEvent.From<PostLikeAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(PostLikeAdminSubscription.OnPostLikeAdminDeleted),
                        PostLikeAdminDeletedEvent.From<PostLikeAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(PostLikeAdminSubscription.OnPostLikeAdminChanged),
                PostLikeAdminChangedEvent.From<PostLikeAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
