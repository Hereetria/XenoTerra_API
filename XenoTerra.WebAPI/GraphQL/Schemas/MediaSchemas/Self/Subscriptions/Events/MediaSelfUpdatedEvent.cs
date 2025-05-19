using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions.Events
{
    public record MediaSelfUpdatedEvent : UpdatedEvent<ResultMediaDto>
    {
    }
}
