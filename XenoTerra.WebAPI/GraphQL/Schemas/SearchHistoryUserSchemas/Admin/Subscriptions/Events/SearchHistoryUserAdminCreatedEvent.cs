using XenoTerra.DTOLayer.Dtos.SearchHistoryUserAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events
{
    public record SearchHistoryUserAdminCreatedEvent : CreatedEvent<ResultSearchHistoryUserAdminDto>
    {
    }
}