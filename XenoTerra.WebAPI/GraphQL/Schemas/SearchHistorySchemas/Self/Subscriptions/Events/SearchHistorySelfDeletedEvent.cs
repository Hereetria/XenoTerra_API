using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Subscriptions.Events
{
    public record SearchHistorySelfDeletedEvent : DeletedEvent<ResultSearchHistoryDto>
    {
    }
}