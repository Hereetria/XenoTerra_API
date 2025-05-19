using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Subscriptions.Events
{
    public record LikeSelfChangedEvent : ChangedEvent<ResultLikeDto>
    {
    }
}
