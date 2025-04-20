using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Subscriptions.Events
{
    public record LikeDeletedEvent : DeletedEvent<ResultLikeDto>
    {
    }
}
