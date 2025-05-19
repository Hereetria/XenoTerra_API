using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events
{
    public record LikeAdminCreatedEvent : CreatedEvent<ResultLikeDto>
    {
    }
}
