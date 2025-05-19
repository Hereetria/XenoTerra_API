using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Subscriptions.Events
{
    public record UserSelfChangedEvent : ChangedEvent<ResultUserPrivateDto>
    {
    }
}
