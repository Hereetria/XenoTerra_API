using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions.Events
{
    public record PostLikeOwnChangedEvent : ChangedEvent<ResultPostLikeOwnDto>
    {
    }
}
