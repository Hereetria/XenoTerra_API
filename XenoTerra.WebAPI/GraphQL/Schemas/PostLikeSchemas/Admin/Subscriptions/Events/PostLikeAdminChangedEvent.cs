using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Admin;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Subscriptions.Events
{
    public record PostLikeAdminChangedEvent : ChangedEvent<ResultPostLikeAdminDto>
    {
    }
}
