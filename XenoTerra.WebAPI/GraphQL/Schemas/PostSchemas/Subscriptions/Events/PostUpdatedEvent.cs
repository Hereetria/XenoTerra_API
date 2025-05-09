using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Subscriptions.Events
{
    public record PostUpdatedEvent : UpdatedEvent<ResultPostDto>
    {
    }
}