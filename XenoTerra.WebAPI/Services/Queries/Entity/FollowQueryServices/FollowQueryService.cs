using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.FollowQueryServices
{
    public class FollowQueryService : QueryService<Follow, ResultFollowWithRelationsDto, Guid>, IFollowQueryService
    {
        public FollowQueryService(IReadService<Follow, ResultFollowWithRelationsDto, Guid> readService, IMapper mapper) : base(readService, mapper)
        {
        }
    }
}
