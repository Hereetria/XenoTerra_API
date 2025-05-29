using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.WebAPI.Helpers;
using FluentValidation;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.HighlightMutationServices;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.BussinessLogicLayer.Services.Entity.HighlightServices;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class HighlightSelfMutation
    {
        public async Task<CreateHighlightSelfPayload> CreateMyHighlightAsync(
            [Service] IHighlightSelfMutationService mutationService,
            [Service] IHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateHighlightSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateHighlightSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateHighlightSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateHighlightSelfInput, CreateHighlightDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateHighlightSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendHighlightEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateHighlightSelfPayload> UpdateMyHighlightAsync(
            [Service] IHighlightSelfMutationService mutationService,
            [Service] IHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateHighlightSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateHighlightSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateHighlightSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateHighlightSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateHighlightSelfInput, UpdateHighlightDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateHighlightSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendHighlightEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteHighlightSelfPayload> DeleteMyHighlightAsync(
            [Service] IHighlightSelfMutationService mutationService,
            [Service] IHighlightReadService readService,
            [Service] IHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var highlight = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.UserId
            );

            if (highlight.UserId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteHighlightSelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendHighlightEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendHighlightEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultHighlightDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(HighlightSelfSubscription.OnHighlightSelfCreated),
                        HighlightSelfCreatedEvent.From<HighlightSelfCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(HighlightSelfSubscription.OnHighlightSelfUpdated),
                        HighlightSelfUpdatedEvent.From<HighlightSelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(HighlightSelfSubscription.OnHighlightSelfDeleted),
                        HighlightSelfDeletedEvent.From<HighlightSelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(HighlightSelfSubscription.OnHighlightSelfChanged),
                HighlightSelfChangedEvent.From<HighlightSelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

