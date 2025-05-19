using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.PostMutationServices
{
    public interface IPostAdminMutationService : IMutationService<Post, ResultPostDto, CreatePostDto, UpdatePostDto, Guid>
    {
    }
}
