using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Http;
using XenoTerra.DTOLayer.Dtos.ReportPostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.ReportPostMutationServices;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReportPostServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class ReportPostSelfMutation
    {
        public async Task<CreateReportPostSelfPayload> CreateMyReportPostAsync(
            [Service] IReportPostSelfMutationService mutationService,
            [Service] IReportPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateReportPostSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateReportPostSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateReportPostSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateReportPostSelfInput, CreateReportPostDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.ReporterUserId = userId;

            var payload = await mutationService.CreateAsync<CreateReportPostSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendReportPostEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateReportPostSelfPayload> UpdateMyReportPostAsync(
            [Service] IReportPostSelfMutationService mutationService,
            [Service] IReportPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateReportPostSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateReportPostSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateReportPostSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateReportPostSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateReportPostSelfInput, UpdateReportPostDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.ReporterUserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateReportPostSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendReportPostEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteReportPostSelfPayload> DeleteMyReportPostAsync(
            [Service] IReportPostSelfMutationService mutationService,
            [Service] IReportPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var payload = await mutationService.DeleteAsync<DeleteReportPostSelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendReportPostEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }

        private async Task SendReportPostEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultReportPostDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(ReportPostSelfSubscription.OnReportPostSelfCreated),
                        ReportPostSelfCreatedEvent.From<ReportPostSelfCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ReportPostSelfSubscription.OnReportPostSelfUpdated),
                        ReportPostSelfUpdatedEvent.From<ReportPostSelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ReportPostSelfSubscription.OnReportPostSelfDeleted),
                        ReportPostSelfDeletedEvent.From<ReportPostSelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ReportPostSelfSubscription.OnReportPostSelfChanged),
                ReportPostSelfChangedEvent.From<ReportPostSelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
