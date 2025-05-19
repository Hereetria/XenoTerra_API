using AutoMapper;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.BlockUserAdminMutationServices
{
    public class BlockUserAdminMutationService(IMapper mapper) 
        : MutationService<BlockUser, ResultBlockUserDto, CreateCommentckUserDto, UpdateBlockUserDto, Guid>(mapper),
        IBlockUserAdminMutationService
    {
    }
}
