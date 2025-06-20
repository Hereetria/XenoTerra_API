using AutoMapper;
using XenoTerra.DTOLayer.Dtos.PostLikeAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.PostLikeMutationServices
{
    public interface IPostLikeOwnMutationService : IMutationService<PostLike, ResultPostLikeOwnDto, CreatePostLikeOwnDto, UpdatePostLikeOwnDto, Guid>
    {
    }
}
