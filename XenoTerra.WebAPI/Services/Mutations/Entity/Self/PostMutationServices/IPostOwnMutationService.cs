using XenoTerra.DTOLayer.Dtos.PostAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.PostMutationServices
{
    public interface IPostOwnMutationService : IMutationService<Post, ResultPostOwnDto, CreatePostOwnDto, UpdatePostOwnDto, Guid>
    {
    }
}
