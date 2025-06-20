using XenoTerra.DTOLayer.Dtos.SavedPostAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Subscriptions.Events
{
    public record SavedPostOwnChangedEvent : ChangedEvent<ResultSavedPostOwnDto>
    {
    }
}