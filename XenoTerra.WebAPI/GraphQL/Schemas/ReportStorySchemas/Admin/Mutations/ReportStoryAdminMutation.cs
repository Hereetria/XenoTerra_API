using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.ReportStoryAdminMutationServices;
using XenoTerra.DTOLayer.Dtos.ReportStoryAdminDtos.Admin;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReportStoryServices.Write.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class ReportStoryAdminMutation
    {
        public async Task<CreateReportStoryAdminPayload> CreateReportStoryAsync(
            [Service] IReportStoryAdminMutationService mutationService,
            [Service] IReportStoryAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateReportStoryAdminInput> inputAdminValidator,
            CreateReportStoryAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateReportStoryAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateReportStoryAdminInput, CreateReportStoryAdminDto>(input);
            var payload = await mutationService.CreateAsync<CreateReportStoryAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendReportStoryEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateReportStoryAdminPayload> UpdateReportStoryAsync(
            [Service] IReportStoryAdminMutationService mutationService,
            [Service] IReportStoryAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateReportStoryAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateReportStoryAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateReportStoryAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateReportStoryAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateReportStoryAdminInput, UpdateReportStoryAdminDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateReportStoryAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendReportStoryEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteReportStoryAdminPayload> DeleteReportStoryAsync(
            [Service] IReportStoryAdminMutationService mutationService,
            [Service] IReportStoryAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteReportStoryAdminPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendReportStoryEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendReportStoryEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultReportStoryAdminDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(ReportStoryAdminSubscription.OnReportStoryAdminCreated),
                        ReportStoryAdminCreatedEvent.From<ReportStoryAdminCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ReportStoryAdminSubscription.OnReportStoryAdminUpdated),
                        ReportStoryAdminUpdatedEvent.From<ReportStoryAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ReportStoryAdminSubscription.OnReportStoryAdminDeleted),
                        ReportStoryAdminDeletedEvent.From<ReportStoryAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ReportStoryAdminSubscription.OnReportStoryAdminChanged),
                ReportStoryAdminChangedEvent.From<ReportStoryAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
