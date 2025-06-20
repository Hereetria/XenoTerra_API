using XenoTerra.DTOLayer.Dtos.ReportStoryAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Subscriptions.Events
{
    public record ReportStoryAdminUpdatedEvent : UpdatedEvent<ResultReportStoryAdminDto>
    {
    }
}
