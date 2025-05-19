using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions.Events
{
    public record BlockUserSelfChangedEvent : ChangedEvent<ResultBlockUserDto>
    {
    }
}
