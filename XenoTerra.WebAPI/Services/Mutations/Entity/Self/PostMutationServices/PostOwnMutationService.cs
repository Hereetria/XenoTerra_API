using AutoMapper;
using XenoTerra.DTOLayer.Dtos.PostAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.PostMutationServices
{
    public class PostOwnMutationService(IMapper mapper)
        : MutationService<Post, ResultPostOwnDto, CreatePostOwnDto, UpdatePostOwnDto, Guid>(mapper),
        IPostOwnMutationService
    {
    }
}
