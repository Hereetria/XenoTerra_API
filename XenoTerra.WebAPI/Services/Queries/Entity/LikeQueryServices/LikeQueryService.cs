using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.LikeQueryServices
{
    public class LikeQueryService : QueryService<Like, ResultLikeWithRelationsDto, Guid>, ILikeQueryService
    {
        public LikeQueryService(IReadService<Like, ResultLikeWithRelationsDto, Guid> readService, IMapper mapper)
            : base(readService, mapper)
        {
        }
    }
}
