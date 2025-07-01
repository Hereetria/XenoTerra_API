using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Subscriptions.Events
{
    public record ReportStoryAdminCreatedEvent : CreatedEvent<ResultReportStoryAdminDto>
    {
    }
}
