using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.CommentLikeQueryServices
{
    public class CommentLikeQueryService : QueryService<CommentLike, Guid>, ICommentLikeQueryService
    {
        public CommentLikeQueryService(IReadService<CommentLike, Guid> readService)
            : base(readService)
        {
        }
    }
}
