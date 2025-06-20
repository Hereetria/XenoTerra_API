using XenoTerra.DTOLayer.Dtos.AppUserDtos.Own.Own;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions.Events
{
    public record UserOwnDeletedEvent : DeletedEvent<ResultAppUserOwnDto>
    {
    }
}
