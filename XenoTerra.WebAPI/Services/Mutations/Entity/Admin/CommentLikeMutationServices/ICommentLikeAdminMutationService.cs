using AutoMapper;
using XenoTerra.DTOLayer.Dtos.CommentLikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.CommentLikeMutationServices
{
    public interface ICommentLikeAdminMutationService : IMutationService<CommentLike, ResultCommentLikeDto, CreateCommentLikeDto, UpdateCommentLikeDto, Guid>
    {
    }
}
