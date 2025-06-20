using XenoTerra.DTOLayer.Dtos.SearchHistoryAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Subscriptions.Events
{
    public record SearchHistoryOwnDeletedEvent : DeletedEvent<ResultSearchHistoryOwnDto>
    {
    }
}