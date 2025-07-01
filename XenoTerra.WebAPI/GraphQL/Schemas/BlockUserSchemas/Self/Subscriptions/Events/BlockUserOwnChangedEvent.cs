using XenoTerra.DTOLayer.Dtos.BlockUserDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions.Events
{
    public record BlockUserOwnChangedEvent : ChangedEvent<ResultBlockUserOwnDto>
    {
    }
}
