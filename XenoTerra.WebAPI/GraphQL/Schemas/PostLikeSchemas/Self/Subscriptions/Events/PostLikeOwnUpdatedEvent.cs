using XenoTerra.DTOLayer.Dtos.PostLikeAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions.Events
{
    public record PostLikeOwnUpdatedEvent : UpdatedEvent<ResultPostLikeOwnDto>
    {
    }
}
