using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Subscriptions.Events
{
    public record ReportCommentChangedEvent : ChangedEvent<ResultReportCommentDto>
    {
    }
}