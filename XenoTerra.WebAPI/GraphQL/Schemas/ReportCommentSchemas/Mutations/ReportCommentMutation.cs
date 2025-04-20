using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReportCommentService;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.ReportCommentMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.ReportCommentMutations
{
    public class ReportCommentMutation
    {
        public async Task<CreateReportCommentPayload> CreateReportCommentAsync(
            [Service] IReportCommentMutationService mutationService,
            [Service] IReportCommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            CreateReportCommentInput? input)
        {
            if (!InputValidator.ValidateInputFields<ReportComment, CreateReportCommentInput, ResultReportCommentDto, CreateReportCommentPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateReportCommentInput, CreateReportCommentDto>(input);
            var payload = await mutationService.CreateAsync<CreateReportCommentPayload>(writeService, createDto);

            await SendReportCommentCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateReportCommentPayload> UpdateReportCommentAsync(
            [Service] IReportCommentMutationService mutationService,
            [Service] IReportCommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateReportCommentInput? input)
        {
            if (!InputValidator.ValidateInputFields<ReportComment, UpdateReportCommentInput, ResultReportCommentDto, UpdateReportCommentPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateReportCommentInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateReportCommentInput, UpdateReportCommentDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateReportCommentPayload>(writeService, updateDto, modifiedFields);

            await SendReportCommentUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteReportCommentPayload> DeleteReportCommentAsync(
            [Service] IReportCommentMutationService mutationService,
            [Service] IReportCommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<ReportComment, ResultReportCommentDto, DeleteReportCommentPayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteReportCommentPayload>(writeService, parsedKey);

            await SendReportCommentDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendReportCommentCreatedEvents(ITopicEventSender sender, ResultReportCommentDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(ReportCommentSubscription.OnReportCommentCreated),
                ReportCommentCreatedEvent.From<ReportCommentCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(ReportCommentSubscription.OnReportCommentChanged),
                ReportCommentChangedEvent.From<ReportCommentChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendReportCommentUpdatedEvents(ITopicEventSender sender, ResultReportCommentDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(ReportCommentSubscription.OnReportCommentUpdated),
                ReportCommentUpdatedEvent.From<ReportCommentUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(ReportCommentSubscription.OnReportCommentChanged),
                ReportCommentChangedEvent.From<ReportCommentChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendReportCommentDeletedEvents(ITopicEventSender sender, ResultReportCommentDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(ReportCommentSubscription.OnReportCommentDeleted),
                ReportCommentDeletedEvent.From<ReportCommentDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(ReportCommentSubscription.OnReportCommentChanged),
                ReportCommentChangedEvent.From<ReportCommentChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}
