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
    public class ReportCommentSelfMutation
    {
        public async Task<CreateReportCommentSelfPayload> CreateReportCommentAsync(
            [Service] IReportCommentMutationService mutationService,
            [Service] IReportCommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreateReportCommentSelfInput> inputSelfValidator,
            CreateReportCommentSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateReportCommentSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateReportCommentSelfInput, CreateReportCommentDto>(input);
            var payload = await mutationService.CreateAsync<CreateReportCommentSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendReportCommentEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateReportCommentSelfPayload> UpdateReportCommentAsync(
            [Service] IReportCommentMutationService mutationService,
            [Service] IReportCommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateReportCommentSelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateReportCommentSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateReportCommentSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateReportCommentSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateReportCommentSelfInput, UpdateReportCommentDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateReportCommentSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendReportCommentEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteReportCommentSelfPayload> DeleteReportCommentAsync(
            [Service] IReportCommentMutationService mutationService,
            [Service] IReportCommentWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteReportCommentSelfPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(ReportCommentSelfSubscription.OnReportCommentCreated),
                        ReportCommentCreatedSelfEvent.From<ReportCommentCreatedSelfEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ReportCommentSelfSubscription.OnReportCommentUpdated),
                        ReportCommentUpdatedSelfEvent.From<ReportCommentUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ReportCommentSelfSubscription.OnReportCommentDeleted),
                        ReportCommentDeletedSelfEvent.From<ReportCommentDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ReportCommentSelfSubscription.OnReportCommentChanged),
                ReportCommentChangedSelfEvent.From<ReportCommentChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
