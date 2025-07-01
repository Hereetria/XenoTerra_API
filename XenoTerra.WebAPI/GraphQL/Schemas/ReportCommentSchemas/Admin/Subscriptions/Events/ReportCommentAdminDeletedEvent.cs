using XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events
{
    public record ReportCommentAdminDeletedEvent : DeletedEvent<ResultReportCommentAdminDto>
    {
    }
}