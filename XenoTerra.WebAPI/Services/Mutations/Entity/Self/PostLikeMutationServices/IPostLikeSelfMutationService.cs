using AutoMapper;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.PostLikeMutationServices
{
    public interface IPostLikeSelfMutationService : IMutationService<PostLike, ResultPostLikeDto, CreatePostLikeDto, UpdatePostLikeDto, Guid>
    {
    }
}
