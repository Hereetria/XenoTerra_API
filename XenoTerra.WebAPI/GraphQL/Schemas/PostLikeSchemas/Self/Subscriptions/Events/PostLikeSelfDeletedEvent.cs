using XenoTerra.DTOLayer.Dtos.PostLikeDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions.Events
{
    public record PostLikeSelfDeletedEvent : DeletedEvent<ResultPostLikeDto>
    {
    }
}
