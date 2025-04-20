using AutoMapper;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.PostMutationServices
{
    public class PostMutationService(IMapper mapper)
        : MutationService<Post, ResultPostDto, CreatePostDto, UpdatePostDto, Guid>(mapper),
        IPostMutationService
    {
    }
}
