using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events
{
    public record SearchHistoryUserChangedSelfEvent : ChangedSelfEvent<ResultSearchHistoryUserDto>
    {
    }
}