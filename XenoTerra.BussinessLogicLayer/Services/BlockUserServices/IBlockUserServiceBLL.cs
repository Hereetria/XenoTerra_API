
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.BlockUserServices
{
        public interface IBlockUserServiceBLL : IGenericRepositoryBLL<BlockUser, ResultBlockUserDto, ResultBlockUserWithRelationsDto, CreateBlockUserDto, UpdateBlockUserDto, Guid>
    {

    }
}