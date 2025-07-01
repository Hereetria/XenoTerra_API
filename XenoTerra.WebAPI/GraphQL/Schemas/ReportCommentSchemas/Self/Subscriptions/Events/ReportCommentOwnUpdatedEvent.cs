using XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions.Events
{
    public record ReportCommentOwnUpdatedEvent : UpdatedEvent<ResultReportCommentOwnDto>
    {
    }
}