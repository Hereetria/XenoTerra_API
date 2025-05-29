using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Http;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReportCommentServices;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.ReportCommentMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class ReportCommentSelfMutation
    {
        public async Task<CreateReportCommentSelfPayload> CreateMyReportCommentAsync(
            [Service] IReportCommentSelfMutationService mutationService,
            [Service] IReportCommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateReportCommentSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateReportCommentSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateReportCommentSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateReportCommentSelfInput, CreateReportCommentDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.ReporterUserId = userId;

            var payload = await mutationService.CreateAsync<CreateReportCommentSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendReportCommentEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateReportCommentSelfPayload> UpdateMyReportCommentAsync(
            [Service] IReportCommentSelfMutationService mutationService,
            [Service] IReportCommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateReportCommentSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateReportCommentSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateReportCommentSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateReportCommentSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateReportCommentSelfInput, UpdateReportCommentDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.ReporterUserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateReportCommentSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendReportCommentEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteReportCommentSelfPayload> DeleteMyReportCommentAsync(
            [Service] IReportCommentSelfMutationService mutationService,
            [Service] IReportCommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var payload = await mutationService.DeleteAsync<DeleteReportCommentSelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendReportCommentEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }

        private async Task SendReportCommentEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultReportCommentDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(ReportCommentSelfSubscription.OnReportCommentSelfCreated),
                        ReportCommentSelfCreatedEvent.From<ReportCommentSelfCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ReportCommentSelfSubscription.OnReportCommentSelfUpdated),
                        ReportCommentSelfUpdatedEvent.From<ReportCommentSelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ReportCommentSelfSubscription.OnReportCommentSelfDeleted),
                        ReportCommentSelfDeletedEvent.From<ReportCommentSelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ReportCommentSelfSubscription.OnReportCommentSelfChanged),
                ReportCommentSelfChangedEvent.From<ReportCommentSelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
