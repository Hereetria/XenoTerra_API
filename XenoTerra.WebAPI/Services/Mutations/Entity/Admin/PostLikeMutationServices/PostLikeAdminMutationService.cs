using AutoMapper;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.PostLikeMutationServices
{
    public class PostLikeAdminMutationService(IMapper mapper)
        : MutationService<PostLike, ResultPostLikeDto, CreatePostLikeDto, UpdatePostLikeDto, Guid>(mapper),
        IPostLikeAdminMutationService
    {
    }
}
