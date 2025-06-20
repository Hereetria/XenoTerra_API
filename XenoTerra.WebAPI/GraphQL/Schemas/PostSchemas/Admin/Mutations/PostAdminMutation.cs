using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.PostMutationServices;
using XenoTerra.DTOLayer.Dtos.PostAdminDtos.Admin;
using XenoTerra.BussinessLogicLayer.Services.Entity.PostServices.Write.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class PostAdminMutation
    {
        public async Task<CreatePostAdminPayload> CreatePostAsync(
            [Service] IPostAdminMutationService mutationService,
            [Service] IPostAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreatePostAdminInput> inputAdminValidator,
            CreatePostAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreatePostAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreatePostAdminInput, CreatePostAdminDto>(input);
            var payload = await mutationService.CreateAsync<CreatePostAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendPostEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdatePostAdminPayload> UpdatePostAsync(
            [Service] IPostAdminMutationService mutationService,
            [Service] IPostAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdatePostAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdatePostAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdatePostAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdatePostAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdatePostAdminInput, UpdatePostAdminDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdatePostAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendPostEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeletePostAdminPayload> DeletePostAsync(
            [Service] IPostAdminMutationService mutationService,
            [Service] IPostAdminWriteService writeService,
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
            ResultPostAdminDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(PostAdminSubscription.OnPostAdminCreated),
                        PostAdminCreatedEvent.From<PostAdminCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(PostAdminSubscription.OnPostAdminUpdated),
                        PostAdminUpdatedEvent.From<PostAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(PostAdminSubscription.OnPostAdminDeleted),
                        PostAdminDeletedEvent.From<PostAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(PostAdminSubscription.OnPostAdminChanged),
                PostAdminChangedEvent.From<PostAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
