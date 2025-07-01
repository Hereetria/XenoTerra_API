using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Http;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Mutations.Inputs;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReportPostServices.Write.Own;
using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Self.Own;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.ReportPostMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class ReportPostOwnMutation
    {
        public async Task<CreateReportPostOwnPayload> CreateOwnReportPostAsync(
            [Service] IReportPostOwnMutationService mutationService,
            [Service] IReportPostOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateReportPostOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateReportPostOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateReportPostOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateReportPostOwnInput, CreateReportPostOwnDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.ReporterUserId = userId;

            var payload = await mutationService.CreateAsync<CreateReportPostOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendReportPostEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateReportPostOwnPayload> UpdateOwnReportPostAsync(
            [Service] IReportPostOwnMutationService mutationService,
            [Service] IReportPostOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateReportPostOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateReportPostOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateReportPostOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateReportPostOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateReportPostOwnInput, UpdateReportPostOwnDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var payload = await mutationService.UpdateAsync<UpdateReportPostOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendReportPostEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteReportPostOwnPayload> DeleteOwnReportPostAsync(
            [Service] IReportPostOwnMutationService mutationService,
            [Service] IReportPostOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var payload = await mutationService.DeleteAsync<DeleteReportPostOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendReportPostEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }

        private async Task SendReportPostEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultReportPostOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(ReportPostOwnSubscription.OnReportPostOwnCreated),
                        ReportPostOwnCreatedEvent.From<ReportPostOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ReportPostOwnSubscription.OnReportPostOwnUpdated),
                        ReportPostOwnUpdatedEvent.From<ReportPostOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ReportPostOwnSubscription.OnReportPostOwnDeleted),
                        ReportPostOwnDeletedEvent.From<ReportPostOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ReportPostOwnSubscription.OnReportPostOwnChanged),
                ReportPostOwnChangedEvent.From<ReportPostOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
