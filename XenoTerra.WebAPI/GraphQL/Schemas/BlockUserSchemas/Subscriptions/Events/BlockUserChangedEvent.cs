using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Subscriptions.Events
{
    public record BlockUserChangedEvent : ChangedEvent<ResultBlockUserDto>
    {
    }
}
