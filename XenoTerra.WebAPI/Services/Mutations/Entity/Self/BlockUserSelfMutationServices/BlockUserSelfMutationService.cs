using AutoMapper;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.BlockUserAdminMutationServices;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.BlockUserSelfMutationServices
{
    public class BlockUserSelfMutationService(IMapper mapper) 
        : MutationService<BlockUser, ResultBlockUserDto, CreateCommentckUserDto, UpdateBlockUserDto, Guid>(mapper),
        IBlockUserSelfMutationService
    {
    }
}
