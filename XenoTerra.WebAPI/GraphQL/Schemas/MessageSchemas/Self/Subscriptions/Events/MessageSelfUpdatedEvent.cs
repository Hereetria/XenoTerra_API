using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions.Events
{
    public record MessageSelfUpdatedEvent : UpdatedEvent<ResultMessageDto>
    {
    }
}
