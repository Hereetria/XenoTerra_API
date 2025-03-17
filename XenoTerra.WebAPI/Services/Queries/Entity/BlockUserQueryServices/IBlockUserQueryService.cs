using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.BlockUserQueryServices
{
    public interface IBlockUserQueryService : IBaseQueryService<BlockUser, ResultBlockUserWithRelationsDto, Guid>
    {
    }
}
