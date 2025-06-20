using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.CommentLikeMutationServices
{
    public interface ICommentLikeAdminMutationService : IMutationService<CommentLike, ResultCommentLikeAdminDto, CreateCommentLikeAdminDto, UpdateCommentLikeAdminDto, Guid>
    {
    }
}