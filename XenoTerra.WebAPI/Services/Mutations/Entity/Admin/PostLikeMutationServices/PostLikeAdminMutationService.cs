using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.PostLikeMutationServices
{
    public class PostLikeAdminMutationService(IMapper mapper)
        : MutationService<PostLike, ResultPostLikeAdminDto, CreatePostLikeAdminDto, UpdatePostLikeAdminDto, Guid>(mapper),
        IPostLikeAdminMutationService
    {
    }
}