
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Services.BlockUserServices
{
    
    public interface IBlockUserServiceDAL : IGenericRepositoryDAL<BlockUser, ResultBlockUserDto, ResultBlockUserWithRelationsDto, CreateBlockUserDto, UpdateBlockUserDto, Guid>

    {

    }
}