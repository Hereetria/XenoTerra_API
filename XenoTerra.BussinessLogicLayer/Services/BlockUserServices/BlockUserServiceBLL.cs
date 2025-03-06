
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.BussinessLogicLayer.Services.BlockUserServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
namespace XenoTerra.BussinessLogicLayer.Services.BlockUserServices
{
     public class BlockUserServiceBLL : GenericRepositoryBLL<BlockUser, ResultBlockUserDto, CreateBlockUserDto, UpdateBlockUserDto, Guid>, IBlockUserServiceBLL
    {
        public BlockUserServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory)
            : base(repositoryDALFactory)
        {
        }
    }
}