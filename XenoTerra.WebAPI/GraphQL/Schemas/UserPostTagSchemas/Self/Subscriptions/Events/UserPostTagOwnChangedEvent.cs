using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Subscriptions.Events
{
    public record UserPostTagOwnChangedEvent : ChangedEvent<ResultUserPostTagOwnDto>
    {
    }
}
