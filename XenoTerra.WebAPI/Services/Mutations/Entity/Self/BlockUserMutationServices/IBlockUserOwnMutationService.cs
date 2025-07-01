using XenoTerra.DTOLayer.Dtos.BlockUserDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.BlockUserMutationServices
{
    public interface IBlockUserOwnMutationService : IMutationService<BlockUser, ResultBlockUserOwnDto, CreateBlockUserOwnDto, UpdateBlockUserOwnDto, Guid>
    {
    }
}
