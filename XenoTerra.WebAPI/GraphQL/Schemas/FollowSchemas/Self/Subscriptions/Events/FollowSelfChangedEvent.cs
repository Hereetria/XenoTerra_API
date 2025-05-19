using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions.Events
{
    public record FollowSelfChangedEvent : ChangedEvent<ResultFollowDto>
    {
    }
}
