using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Subscriptions.Events
{
    public record SearchHistoryUserDeletedEvent : DeletedEvent<ResultSearchHistoryUserDto>
    {
    }
}