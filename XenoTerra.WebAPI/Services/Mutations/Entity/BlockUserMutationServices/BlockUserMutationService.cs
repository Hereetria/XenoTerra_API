using AutoMapper;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.BlockUserMutationServices
{
    public class BlockUserMutationService(IMapper mapper) 
        : MutationService<BlockUser, ResultBlockUserDto, CreateBlockUserDto, UpdateBlockUserDto, Guid>(mapper),
        IBlockUserMutationService
    {
    }
}
