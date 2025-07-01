using AutoMapper;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.PostLikeMutationServices
{
    public interface IPostLikeOwnMutationService : IMutationService<PostLike, ResultPostLikeOwnDto, CreatePostLikeOwnDto, UpdatePostLikeOwnDto, Guid>
    {
    }
}
