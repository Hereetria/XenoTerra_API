using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Subscriptions.Events
{
    public record ReportStoryOwnDeletedEvent : DeletedEvent<ResultReportStoryOwnDto>
    {
    }
}
