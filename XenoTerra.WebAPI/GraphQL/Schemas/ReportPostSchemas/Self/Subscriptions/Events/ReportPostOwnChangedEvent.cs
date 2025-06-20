using XenoTerra.DTOLayer.Dtos.ReportPostAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions.Events
{
    public record ReportPostOwnChangedEvent : ChangedEvent<ResultReportPostOwnDto>
    {
    }
}