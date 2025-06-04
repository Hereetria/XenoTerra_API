using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.PostLikeQueryServices
{
    public class PostLikeQueryService : QueryService<PostLike, Guid>, IPostLikeQueryService
    {
        public PostLikeQueryService(IReadService<PostLike, Guid> readService)
            : base(readService)
        {
        }
    }
}
