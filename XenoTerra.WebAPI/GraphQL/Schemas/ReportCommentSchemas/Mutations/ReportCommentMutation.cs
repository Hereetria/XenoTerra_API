using FluentValidation;
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
            [Service] IValidator<CreateReportCommentInput> inputValidator,
            CreateReportCommentInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateReportCommentInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateReportCommentInput, CreateReportCommentDto>(input);
            var payload = await mutationService.CreateAsync<CreateReportCommentPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendReportCommentEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateReportCommentPayload> UpdateReportCommentAsync(
            [Service] IReportCommentMutationService mutationService,
            [Service] IReportCommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateReportCommentInput> inputValidator,
            IResolverContext context,
            UpdateReportCommentInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateReportCommentInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateReportCommentInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateReportCommentInput, UpdateReportCommentDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateReportCommentPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendReportCommentEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteReportCommentPayload> DeleteReportCommentAsync(
            [Service] IReportCommentMutationService mutationService,
            [Service] IReportCommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteReportCommentPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(ReportCommentSubscription.OnReportCommentCreated),
                        ReportCommentCreatedEvent.From<ReportCommentCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ReportCommentSubscription.OnReportCommentUpdated),
                        ReportCommentUpdatedEvent.From<ReportCommentUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ReportCommentSubscription.OnReportCommentDeleted),
                        ReportCommentDeletedEvent.From<ReportCommentDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ReportCommentSubscription.OnReportCommentChanged),
                ReportCommentChangedEvent.From<ReportCommentChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
