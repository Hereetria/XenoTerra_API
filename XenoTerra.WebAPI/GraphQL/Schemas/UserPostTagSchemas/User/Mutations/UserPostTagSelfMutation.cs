using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserPostTagServices;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.UserPostTagMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Mutations
{
    public class UserPostTagSelfMutation
    {
        public async Task<CreateUserPostTagSelfPayload> CreateUserPostTagAsync(
            [Service] IUserPostTagMutationService mutationService,
            [Service] IUserPostTagWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreateUserPostTagSelfInput> inputSelfValidator,
            CreateUserPostTagSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateUserPostTagSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateUserPostTagSelfInput, CreateUserPostTagDto>(input);
            var payload = await mutationService.CreateAsync<CreateUserPostTagSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendUserPostTagEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateUserPostTagSelfPayload> UpdateUserPostTagAsync(
            [Service] IUserPostTagMutationService mutationService,
            [Service] IUserPostTagWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateUserPostTagSelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateUserPostTagSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateUserPostTagSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateUserPostTagSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateUserPostTagSelfInput, UpdateUserPostTagDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateUserPostTagSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendUserPostTagEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteUserPostTagSelfPayload> DeleteUserPostTagAsync(
            [Service] IUserPostTagMutationService mutationService,
            [Service] IUserPostTagWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var payload = await mutationService.DeleteAsync<DeleteUserPostTagSelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendUserPostTagEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendUserPostTagEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultUserPostTagDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(UserPostTagSelfSubscription.OnUserPostTagCreated),
                        UserPostTagCreatedSelfEvent.From<UserPostTagCreatedSelfEvent>(result, userId, now));
                    break;
                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(UserPostTagSelfSubscription.OnUserPostTagUpdated),
                        UserPostTagUpdatedSelfEvent.From<UserPostTagUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;
                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(UserPostTagSelfSubscription.OnUserPostTagDeleted),
                        UserPostTagDeletedSelfEvent.From<UserPostTagDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(UserPostTagSelfSubscription.OnUserPostTagChanged),
                UserPostTagChangedSelfEvent.From<UserPostTagChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
