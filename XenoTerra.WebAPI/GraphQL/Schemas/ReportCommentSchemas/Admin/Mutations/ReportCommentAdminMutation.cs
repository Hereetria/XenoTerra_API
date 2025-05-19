using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReportCommentServices;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.ReportCommentMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class ReportCommentAdminMutation
    {
        public async Task<CreateReportCommentAdminPayload> CreateReportCommentAsync(
            [Service] IReportCommentAdminMutationService mutationService,
            [Service] IReportCommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateReportCommentAdminInput> inputAdminValidator,
            CreateReportCommentAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateReportCommentAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateReportCommentAdminInput, CreateReportCommentDto>(input);
            var payload = await mutationService.CreateAsync<CreateReportCommentAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendReportCommentEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateReportCommentAdminPayload> UpdateReportCommentAsync(
            [Service] IReportCommentAdminMutationService mutationService,
            [Service] IReportCommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateReportCommentAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateReportCommentAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateReportCommentAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateReportCommentAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateReportCommentAdminInput, UpdateReportCommentDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateReportCommentAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendReportCommentEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteReportCommentAdminPayload> DeleteReportCommentAsync(
            [Service] IReportCommentAdminMutationService mutationService,
            [Service] IReportCommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteReportCommentAdminPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendReportCommentEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendReportCommentEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultReportCommentDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(ReportCommentAdminSubscription.OnReportCommentAdminCreated),
                        ReportCommentAdminCreatedEvent.From<ReportCommentAdminCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ReportCommentAdminSubscription.OnReportCommentAdminUpdated),
                        ReportCommentAdminUpdatedEvent.From<ReportCommentAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ReportCommentAdminSubscription.OnReportCommentAdminDeleted),
                        ReportCommentAdminDeletedEvent.From<ReportCommentAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ReportCommentAdminSubscription.OnReportCommentAdminChanged),
                ReportCommentAdminChangedEvent.From<ReportCommentAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
