using XenoTerra.DTOLayer.Dtos.PostLikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;

namespace XenoTerra.WebAPI.GraphQL.Resolvers.Entity.PostLikeResolvers
{
    public interface IPostLikeResolver : IEntityResolver<PostLike, Guid>
    {
    }
}
