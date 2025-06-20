using XenoTerra.DTOLayer.Dtos.BlockUserAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.BlockUserOwnMutationServices
{
    public interface IBlockUserOwnMutationService : IMutationService<BlockUser, ResultBlockUserOwnDto, CreateBlockUserOwnDto, UpdateBlockUserOwnDto, Guid>
    {
    }
}
