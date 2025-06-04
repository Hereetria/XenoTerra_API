using XenoTerra.DTOLayer.Dtos.PostLikeDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Subscriptions.Events
{
    public record PostLikeAdminCreatedEvent : CreatedEvent<ResultPostLikeDto>
    {
    }
}
