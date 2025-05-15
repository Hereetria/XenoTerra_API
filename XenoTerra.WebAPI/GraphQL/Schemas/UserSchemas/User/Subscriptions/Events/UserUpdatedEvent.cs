using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions.Events
{
    public record UserUpdatedEvent : UpdatedEvent<ResultUserDto>
    {
    }
}
