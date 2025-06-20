using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.CommentLikeMutationServices
{
    public class CommentLikeAdminMutationService(IMapper mapper)
        : MutationService<CommentLike, ResultCommentLikeAdminDto, CreateCommentLikeAdminDto, UpdateCommentLikeAdminDto, Guid>(mapper),
        ICommentLikeAdminMutationService
    {
    }
}