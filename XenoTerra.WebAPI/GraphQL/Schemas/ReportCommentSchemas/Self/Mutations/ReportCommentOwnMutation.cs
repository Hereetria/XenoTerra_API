using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Http;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Mutations.Inputs;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReportCommentServices.Write.Own;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Self.Own;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.ReportCommentMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class ReportCommentOwnMutation
    {
        public async Task<CreateReportCommentOwnPayload> CreateOwnReportCommentAsync(
            [Service] IReportCommentOwnMutationService mutationService,
            [Service] IReportCommentOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateReportCommentOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateReportCommentOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateReportCommentOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateReportCommentOwnInput, CreateReportCommentOwnDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.ReporterUserId = userId;

            var payload = await mutationService.CreateAsync<CreateReportCommentOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendReportCommentEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateReportCommentOwnPayload> UpdateOwnReportCommentAsync(
            [Service] IReportCommentOwnMutationService mutationService,
            [Service] IReportCommentOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateReportCommentOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateReportCommentOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateReportCommentOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateReportCommentOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateReportCommentOwnInput, UpdateReportCommentOwnDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var payload = await mutationService.UpdateAsync<UpdateReportCommentOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendReportCommentEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteReportCommentOwnPayload> DeleteOwnReportCommentAsync(
            [Service] IReportCommentOwnMutationService mutationService,
            [Service] IReportCommentOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var payload = await mutationService.DeleteAsync<DeleteReportCommentOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendReportCommentEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }

        private async Task SendReportCommentEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultReportCommentOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(ReportCommentOwnSubscription.OnReportCommentOwnCreated),
                        ReportCommentOwnCreatedEvent.From<ReportCommentOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ReportCommentOwnSubscription.OnReportCommentOwnUpdated),
                        ReportCommentOwnUpdatedEvent.From<ReportCommentOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ReportCommentOwnSubscription.OnReportCommentOwnDeleted),
                        ReportCommentOwnDeletedEvent.From<ReportCommentOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ReportCommentOwnSubscription.OnReportCommentOwnChanged),
                ReportCommentOwnChangedEvent.From<ReportCommentOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
