using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Subscriptions.Events
{
    public record MediaCreatedEvent : CreatedEvent<ResultMediaDto>
    {
    }
}
