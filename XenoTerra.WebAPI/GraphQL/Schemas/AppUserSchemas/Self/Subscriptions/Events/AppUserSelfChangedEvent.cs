using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions.Events
{
    public record UserSelfChangedEvent : ChangedEvent<ResultAppUserPrivateDto>
    {
    }
}
