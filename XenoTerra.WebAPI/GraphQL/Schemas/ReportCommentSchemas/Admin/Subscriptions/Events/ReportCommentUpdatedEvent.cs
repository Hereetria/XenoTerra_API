using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events
{
    public record ReportCommentUpdatedEvent : UpdatedEvent<ResultReportCommentDto>
    {
    }
}