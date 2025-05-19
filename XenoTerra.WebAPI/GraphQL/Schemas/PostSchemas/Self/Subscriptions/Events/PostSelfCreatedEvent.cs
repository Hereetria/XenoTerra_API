using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions.Events
{
    public record PostSelfCreatedEvent : CreatedEvent<ResultPostDto>
    {
    }
}