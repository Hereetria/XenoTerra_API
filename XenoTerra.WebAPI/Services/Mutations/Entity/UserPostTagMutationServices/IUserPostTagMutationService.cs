using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.UserPostTagMutationServices
{
    public interface IUserPostTagMutationService : IMutationService<UserPostTag, ResultUserPostTagDto, CreateUserPostTagDto, UpdateUserPostTagDto, Guid>
    {
    }
}
