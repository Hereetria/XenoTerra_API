using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Mutations.Payloads;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReportStoryServices.Read;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReportStoryServices.Write.Own;
using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Self.Own;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.ReportStorySelfMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class ReportStoryOwnMutation
    {
        public async Task<CreateReportStoryOwnPayload> CreateOwnReportStoryAsync(
            [Service] IReportStoryOwnMutationService mutationService,
            [Service] IReportStoryOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateReportStoryOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateReportStoryOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateReportStoryOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateReportStoryOwnInput, CreateReportStoryOwnDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.ReporterUserId = userId;

            var payload = await mutationService.CreateAsync<CreateReportStoryOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendReportStoryEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateReportStoryOwnPayload> UpdateOwnReportStoryAsync(
            [Service] IReportStoryOwnMutationService mutationService,
            [Service] IReportStoryOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateReportStoryOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateReportStoryOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateReportStoryOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateReportStoryOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateReportStoryOwnInput, UpdateReportStoryOwnDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var payload = await mutationService.UpdateAsync<UpdateReportStoryOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendReportStoryEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteReportStoryOwnPayload> DeleteOwnReportStoryAsync(
            [Service] IReportStoryOwnMutationService mutationService,
            [Service] IReportStoryReadService readService,
            [Service] IReportStoryOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var like = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.ReporterUserId
            );

            if (like.ReporterUserId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteReportStoryOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendReportStoryEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendReportStoryEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultReportStoryOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(ReportStoryOwnSubscription.OnReportStoryOwnCreated),
                        ReportStoryOwnCreatedEvent.From<ReportStoryOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ReportStoryOwnSubscription.OnReportStoryOwnUpdated),
                        ReportStoryOwnUpdatedEvent.From<ReportStoryOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ReportStoryOwnSubscription.OnReportStoryOwnDeleted),
                        ReportStoryOwnDeletedEvent.From<ReportStoryOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ReportStoryOwnSubscription.OnReportStoryOwnChanged),
                ReportStoryOwnChangedEvent.From<ReportStoryOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

