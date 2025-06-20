using XenoTerra.DTOLayer.Dtos.ReportPostAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Subscriptions.Events
{
    public record ReportPostAdminChangedEvent : ChangedEvent<ResultReportPostAdminDto>
    {
    }
}