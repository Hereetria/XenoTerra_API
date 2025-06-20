using XenoTerra.DTOLayer.Dtos.ReportStoryAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Subscriptions.Events
{
    public record ReportStoryOwnUpdatedEvent : UpdatedEvent<ResultReportStoryOwnDto>
    {
    }
}
