using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.BlockUserQueryServices
{
    public class BlockUserQueryService : QueryService<BlockUser, Guid>, IBlockUserQueryService
    {
        public BlockUserQueryService(IReadService<BlockUser, Guid> readService, IMapper mapper) : base(readService, mapper)
        {
        }
    }
}
