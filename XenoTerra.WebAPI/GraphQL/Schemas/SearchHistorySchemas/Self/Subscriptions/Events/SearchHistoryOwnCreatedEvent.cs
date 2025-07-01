using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Subscriptions.Events
{
    public record SearchHistoryOwnCreatedEvent : CreatedEvent<ResultSearchHistoryOwnDto>
    {
    }
}