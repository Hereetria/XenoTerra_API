using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events
{
    public record SearchHistoryUserAdminDeletedEvent : DeletedEvent<ResultSearchHistoryUserDto>
    {
    }
}