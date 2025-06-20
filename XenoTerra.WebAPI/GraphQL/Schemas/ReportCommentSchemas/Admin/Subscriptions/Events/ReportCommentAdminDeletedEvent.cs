using XenoTerra.DTOLayer.Dtos.ReportCommentAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events
{
    public record ReportCommentAdminDeletedEvent : DeletedEvent<ResultReportCommentAdminDto>
    {
    }
}