using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.UserPostTagMutationServices
{
    public interface IUserPostTagSelfMutationService : IMutationService<UserPostTag, ResultUserPostTagDto, CreateUserPostTagDto, UpdateUserPostTagDto, Guid>
    {
    }
}
