using AutoMapper;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.BlockUserAdminMutationServices;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.BlockUserMutationServices
{
    public class BlockUserOwnMutationService(IMapper mapper) 
        : MutationService<BlockUser, ResultBlockUserOwnDto, CreateBlockUserOwnDto, UpdateBlockUserOwnDto, Guid>(mapper),
        IBlockUserOwnMutationService
    {
    }
}
