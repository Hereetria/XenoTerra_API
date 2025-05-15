using GreenDonut;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events
{
    public record BlockUserDeletedEvent : DeletedEvent<ResultBlockUserDto>
    {
    }
}
