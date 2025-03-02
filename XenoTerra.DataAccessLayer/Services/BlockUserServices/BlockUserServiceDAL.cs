

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.BlockUserServices
{
    
    public class BlockUserServiceDAL : GenericRepositoryDAL<BlockUser, ResultBlockUserDto, ResultBlockUserByIdDto, CreateBlockUserDto, UpdateBlockUserDto, Guid>, IBlockUserServiceDAL

    {

        public BlockUserServiceDAL(Context context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}