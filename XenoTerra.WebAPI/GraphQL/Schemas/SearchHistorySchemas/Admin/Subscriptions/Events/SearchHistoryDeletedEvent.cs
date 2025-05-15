using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events
{
    public record SearchHistoryDeletedEvent : DeletedEvent<ResultSearchHistoryDto>
    {
    }
}