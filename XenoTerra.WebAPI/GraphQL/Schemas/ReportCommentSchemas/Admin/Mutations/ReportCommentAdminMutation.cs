using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReportCommentService;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.ReportCommentMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Mutations
{
    public class ReportCommentAdminMutation
    {
        public async Task<CreateReportCommentAdminPayload> CreateReportCommentAsync(
            [Service] IReportCommentMutationService mutationService,
            [Service] IReportCommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<CreateReportCommentAdminInput> inputAdminValidator,
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
            [Service] IReportCommentMutationService mutationService,
            [Service] IReportCommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<UpdateReportCommentAdminInput> inputAdminValidator,
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
            [Service] IReportCommentMutationService mutationService,
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
                    await sender.SendAsync(nameof(ReportCommentAdminSubscription.OnReportCommentCreated),
                        ReportCommentCreatedAdminEvent.From<ReportCommentCreatedAdminEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ReportCommentAdminSubscription.OnReportCommentUpdated),
                        ReportCommentUpdatedAdminEvent.From<ReportCommentUpdatedAdminEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ReportCommentAdminSubscription.OnReportCommentDeleted),
                        ReportCommentDeletedAdminEvent.From<ReportCommentDeletedAdminEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ReportCommentAdminSubscription.OnReportCommentChanged),
                ReportCommentChangedAdminEvent.From<ReportCommentChangedAdminEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
