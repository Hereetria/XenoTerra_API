using XenoTerra.DTOLayer.Dtos.ReportCommentAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions.Events
{
    public record ReportCommentOwnChangedEvent : ChangedEvent<ResultReportCommentOwnDto>
    {
    }
}