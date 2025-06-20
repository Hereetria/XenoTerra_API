
using XenoTerra.DTOLayer.Dtos.PostLikeAdminDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Subscriptions.Events
{
    public record PostLikeAdminChangedEvent : ChangedEvent<ResultPostLikeAdminDto>
    {
    }
}
