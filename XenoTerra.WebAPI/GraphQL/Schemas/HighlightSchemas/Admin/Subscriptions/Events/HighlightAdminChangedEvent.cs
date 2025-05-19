using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events
{
    public record HighlightAdminChangedEvent : ChangedEvent<ResultHighlightDto>
    {
    }
}
