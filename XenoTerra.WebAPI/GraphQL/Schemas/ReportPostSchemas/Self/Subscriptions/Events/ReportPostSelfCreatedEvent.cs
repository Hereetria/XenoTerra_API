using XenoTerra.DTOLayer.Dtos.ReportPostDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions.Events
{
    public record ReportPostSelfCreatedEvent : CreatedEvent<ResultReportPostDto>
    {
    }
}