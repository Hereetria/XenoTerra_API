using AutoMapper;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.PostMutationServices
{
    public class PostAdminMutationService(IMapper mapper)
        : MutationService<Post, ResultPostDto, CreatePostDto, UpdatePostDto, Guid>(mapper),
        IPostAdminMutationService
    {
    }
}
