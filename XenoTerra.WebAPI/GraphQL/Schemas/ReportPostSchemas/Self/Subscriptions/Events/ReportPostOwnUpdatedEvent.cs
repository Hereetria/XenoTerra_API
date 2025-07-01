using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions.Events
{
    public record ReportPostOwnUpdatedEvent : UpdatedEvent<ResultReportPostOwnDto>
    {
    }
}