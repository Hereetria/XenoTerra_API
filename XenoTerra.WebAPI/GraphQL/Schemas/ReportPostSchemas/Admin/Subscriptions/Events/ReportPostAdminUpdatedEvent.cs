using XenoTerra.DTOLayer.Dtos.ReportPostDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Subscriptions.Events
{
    public record ReportPostAdminUpdatedEvent : UpdatedEvent<ResultReportPostDto>
    {
    }
}