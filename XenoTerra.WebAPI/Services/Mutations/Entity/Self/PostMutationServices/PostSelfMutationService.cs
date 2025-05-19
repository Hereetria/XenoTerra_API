using AutoMapper;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.PostMutationServices
{
    public class PostSelfMutationService(IMapper mapper)
        : MutationService<Post, ResultPostDto, CreatePostDto, UpdatePostDto, Guid>(mapper),
        IPostSelfMutationService
    {
    }
}
