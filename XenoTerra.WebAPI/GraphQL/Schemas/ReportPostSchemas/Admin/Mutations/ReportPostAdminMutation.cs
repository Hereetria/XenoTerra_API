using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.ReportPostMutationServices;
using XenoTerra.DTOLayer.Dtos.ReportPostAdminDtos.Admin;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReportPostServices.Write.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class ReportPostAdminMutation
    {
        public async Task<CreateReportPostAdminPayload> CreateReportPostAsync(
            [Service] IReportPostAdminMutationService mutationService,
            [Service] IReportPostAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateReportPostAdminInput> inputAdminValidator,
            CreateReportPostAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateReportPostAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateReportPostAdminInput, CreateReportPostAdminDto>(input);
            var payload = await mutationService.CreateAsync<CreateReportPostAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendReportPostEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateReportPostAdminPayload> UpdateReportPostAsync(
            [Service] IReportPostAdminMutationService mutationService,
            [Service] IReportPostAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateReportPostAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateReportPostAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateReportPostAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateReportPostAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateReportPostAdminInput, UpdateReportPostAdminDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateReportPostAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendReportPostEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteReportPostAdminPayload> DeleteReportPostAsync(
            [Service] IReportPostAdminMutationService mutationService,
            [Service] IReportPostAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteReportPostAdminPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendReportPostEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendReportPostEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultReportPostAdminDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(ReportPostAdminSubscription.OnReportPostAdminCreated),
                        ReportPostAdminCreatedEvent.From<ReportPostAdminCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ReportPostAdminSubscription.OnReportPostAdminUpdated),
                        ReportPostAdminUpdatedEvent.From<ReportPostAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ReportPostAdminSubscription.OnReportPostAdminDeleted),
                        ReportPostAdminDeletedEvent.From<ReportPostAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ReportPostAdminSubscription.OnReportPostAdminChanged),
                ReportPostAdminChangedEvent.From<ReportPostAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
