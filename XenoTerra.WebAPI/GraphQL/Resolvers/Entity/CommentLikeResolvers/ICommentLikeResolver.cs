using XenoTerra.DTOLayer.Dtos.CommentLikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;

namespace XenoTerra.WebAPI.GraphQL.Resolvers.Entity.CommentLikeResolvers
{
    public interface ICommentLikeResolver : IEntityResolver<CommentLike, Guid>
    {
    }
}
