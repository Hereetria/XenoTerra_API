using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions.Events
{
    public record ReportCommentSelfChangedEvent : ChangedEvent<ResultReportCommentDto>
    {
    }
}