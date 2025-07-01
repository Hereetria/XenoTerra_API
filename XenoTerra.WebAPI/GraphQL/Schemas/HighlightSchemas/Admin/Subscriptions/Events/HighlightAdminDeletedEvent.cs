using XenoTerra.DTOLayer.Dtos.HighlightDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events
{
    public record HighlightAdminDeletedEvent : DeletedEvent<ResultHighlightAdminDto>
    {
    }
}
