using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.UserPostTagMutationServices
{
    public interface IUserPostTagOwnMutationService : IMutationService<UserPostTag, ResultUserPostTagOwnDto, CreateUserPostTagOwnDto, UpdateUserPostTagOwnDto, Guid>
    {
    }
}
