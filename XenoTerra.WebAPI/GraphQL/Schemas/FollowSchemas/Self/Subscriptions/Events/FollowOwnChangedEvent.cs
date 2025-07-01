using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions.Events
{
    public record FollowOwnChangedEvent : ChangedEvent<ResultFollowOwnDto>
    {
    }
}
