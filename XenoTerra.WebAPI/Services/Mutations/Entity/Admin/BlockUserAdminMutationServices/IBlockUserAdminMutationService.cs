using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.Admin;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.BlockUserAdminMutationServices
{
    public interface IBlockUserAdminMutationService : IMutationService<BlockUser, ResultBlockUserAdminDto, CreateBlockUserAdminDto, UpdateBlockUserAdminDto, Guid>
    {
    }
}