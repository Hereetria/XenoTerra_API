using XenoTerra.DTOLayer.Dtos.CommentLikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.CommentLikeQueryServices
{
    public interface ICommentLikeQueryService : IQueryService<CommentLike, Guid>
    {
    }

}
