using XenoTerra.DTOLayer.Dtos.SearchHistoryAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events
{
    public record SearchHistoryAdminDeletedEvent : DeletedEvent<ResultSearchHistoryAdminDto>
    {
    }
}