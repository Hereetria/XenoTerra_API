using AutoMapper;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.PostLikeMutationServices
{
    public interface IPostLikeAdminMutationService : IMutationService<PostLike, ResultPostLikeDto, CreatePostLikeDto, UpdatePostLikeDto, Guid>
    {
    }
}
