using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events
{
    public record SearchHistoryAdminChangedEvent : ChangedEvent<ResultSearchHistoryDto>
    {
    }
}