using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.CommentResolvers
{
    public interface ICommentResolver : IEntityResolver<Comment, ResultCommentWithRelationsDto, Guid>
    {
    }
}
