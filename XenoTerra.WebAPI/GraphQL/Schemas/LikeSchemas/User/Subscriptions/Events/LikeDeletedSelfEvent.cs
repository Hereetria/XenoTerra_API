using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events
{
    public record LikeDeletedSelfEvent : DeletedSelfEvent<ResultLikeDto>
    {
    }
}
