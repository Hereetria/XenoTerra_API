using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.PostAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.PostMutationServices
{
    public interface IPostAdminMutationService : IMutationService<Post, ResultPostAdminDto, CreatePostAdminDto, UpdatePostAdminDto, Guid>
    {
    }
}