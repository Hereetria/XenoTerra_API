using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.LikeQueryServices
{
    public class LikeQueryService : QueryService<Like, Guid>, ILikeQueryService
    {
        public LikeQueryService(IReadService<Like, Guid> readService)
            : base(readService)
        {
        }
    }
}
