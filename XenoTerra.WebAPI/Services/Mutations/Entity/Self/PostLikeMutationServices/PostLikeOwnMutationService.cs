using AutoMapper;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.PostLikeMutationServices
{
    public class PostLikeOwnMutationService(IMapper mapper)
        : MutationService<PostLike, ResultPostLikeOwnDto, CreatePostLikeOwnDto, UpdatePostLikeOwnDto, Guid>(mapper),
        IPostLikeOwnMutationService
    {
    }
}
