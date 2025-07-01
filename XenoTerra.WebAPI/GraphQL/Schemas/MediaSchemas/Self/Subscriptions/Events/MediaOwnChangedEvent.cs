using XenoTerra.DTOLayer.Dtos.MediaDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions.Events
{
    public record MediaOwnChangedEvent : ChangedEvent<ResultMediaOwnDto>
    {
    }
}
