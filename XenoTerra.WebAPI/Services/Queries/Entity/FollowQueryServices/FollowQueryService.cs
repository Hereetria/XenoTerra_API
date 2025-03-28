using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.FollowQueryServices
{
    public class FollowQueryService : QueryService<Follow, Guid>, IFollowQueryService
    {
        public FollowQueryService(IReadService<Follow, Guid> readService) : base(readService)
        {
        }
    }
}
