using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.WebAPI.Helpers;
using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions.Events;
using XenoTerra.BussinessLogicLayer.Services.Entity.HighlightServices.Read;
using XenoTerra.BussinessLogicLayer.Services.Entity.HighlightServices.Write.Own;
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Own;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.HighlightMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class HighlightOwnMutation
    {
        public async Task<CreateHighlightOwnPayload> CreateOwnHighlightAsync(
            [Service] IHighlightOwnMutationService mutationService,
            [Service] IHighlightOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateHighlightOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateHighlightOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateHighlightOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateHighlightOwnInput, CreateHighlightOwnDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateHighlightOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendHighlightEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateHighlightOwnPayload> UpdateOwnHighlightAsync(
            [Service] IHighlightOwnMutationService mutationService,
            [Service] IHighlightOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateHighlightOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateHighlightOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateHighlightOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateHighlightOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateHighlightOwnInput, UpdateHighlightOwnDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var payload = await mutationService.UpdateAsync<UpdateHighlightOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendHighlightEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteHighlightOwnPayload> DeleteOwnHighlightAsync(
            [Service] IHighlightOwnMutationService mutationService,
            [Service] IHighlightReadService readService,
            [Service] IHighlightOwnWriteService writeService,
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

            var payload = await mutationService.DeleteAsync<DeleteHighlightOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendHighlightEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendHighlightEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultHighlightOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(HighlightOwnSubscription.OnHighlightOwnCreated),
                        HighlightOwnCreatedEvent.From<HighlightOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(HighlightOwnSubscription.OnHighlightOwnUpdated),
                        HighlightOwnUpdatedEvent.From<HighlightOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(HighlightOwnSubscription.OnHighlightOwnDeleted),
                        HighlightOwnDeletedEvent.From<HighlightOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(HighlightOwnSubscription.OnHighlightOwnChanged),
                HighlightOwnChangedEvent.From<HighlightOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

