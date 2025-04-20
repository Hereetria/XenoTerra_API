using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Subscriptions.Events
{
    public record HighlightUpdatedEvent : UpdatedEvent<ResultHighlightDto>
    {
    }
}
