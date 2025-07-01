using AutoMapper;
using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.PostMutationServices
{
    public class PostOwnMutationService(IMapper mapper)
        : MutationService<Post, ResultPostOwnDto, CreatePostOwnDto, UpdatePostOwnDto, Guid>(mapper),
        IPostOwnMutationService
    {
    }
}
