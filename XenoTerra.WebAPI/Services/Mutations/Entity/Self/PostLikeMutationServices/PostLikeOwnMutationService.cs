using AutoMapper;
using XenoTerra.DTOLayer.Dtos.PostLikeAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.PostLikeMutationServices
{
    public class PostLikeOwnMutationService(IMapper mapper)
        : MutationService<PostLike, ResultPostLikeOwnDto, CreatePostLikeOwnDto, UpdatePostLikeOwnDto, Guid>(mapper),
        IPostLikeOwnMutationService
    {
    }
}
