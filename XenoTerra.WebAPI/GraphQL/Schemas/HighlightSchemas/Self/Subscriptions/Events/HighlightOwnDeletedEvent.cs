using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions.Events
{
    public record HighlightOwnDeletedEvent : DeletedEvent<ResultHighlightOwnDto>
    {
    }
}
