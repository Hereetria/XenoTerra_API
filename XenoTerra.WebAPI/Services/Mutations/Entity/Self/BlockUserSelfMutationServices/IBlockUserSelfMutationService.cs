using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.BlockUserSelfMutationServices
{
    public interface IBlockUserSelfMutationService : IMutationService<BlockUser, ResultBlockUserDto, CreateCommentckUserDto, UpdateBlockUserDto, Guid>
    {
    }
}
