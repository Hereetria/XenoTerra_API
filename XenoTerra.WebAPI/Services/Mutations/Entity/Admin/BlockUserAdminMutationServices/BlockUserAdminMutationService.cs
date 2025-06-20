using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.BlockUserAdminDtos.Admin;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.BlockUserAdminMutationServices
{
    public class BlockUserAdminMutationService(IMapper mapper) 
        : MutationService<BlockUser, ResultBlockUserAdminDto, CreateBlockUserAdminDto, UpdateBlockUserAdminDto, Guid>(mapper),
        IBlockUserAdminMutationService
    {
    }
}