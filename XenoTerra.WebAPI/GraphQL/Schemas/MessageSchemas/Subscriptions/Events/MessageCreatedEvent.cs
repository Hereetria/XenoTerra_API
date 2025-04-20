using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Subscriptions.Events
{
    public record MessageCreatedEvent : CreatedEvent<ResultMessageDto>
    {
    }
}
