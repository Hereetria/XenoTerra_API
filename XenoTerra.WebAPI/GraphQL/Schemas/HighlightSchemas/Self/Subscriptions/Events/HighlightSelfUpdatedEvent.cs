using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions.Events
{
    public record HighlightSelfUpdatedEvent : UpdatedEvent<ResultHighlightDto>
    {
    }
}
