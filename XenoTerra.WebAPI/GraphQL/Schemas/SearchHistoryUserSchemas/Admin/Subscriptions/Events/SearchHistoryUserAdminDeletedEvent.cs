using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events
{
    public record SearchHistoryUserAdminDeletedEvent : DeletedEvent<ResultSearchHistoryUserAdminDto>
    {
    }
}