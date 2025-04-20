using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Subscriptions.Events
{
    public record FollowChangedEvent : ChangedEvent<ResultFollowDto>
    {
    }
}
