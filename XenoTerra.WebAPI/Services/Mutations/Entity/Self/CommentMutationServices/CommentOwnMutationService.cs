using AutoMapper;
using XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.CommentMutationServices
{
    public class CommentOwnMutationService(IMapper mapper)
        : MutationService<Comment, ResultCommentOwnDto, CreateCommentOwnDto, UpdateCommentOwnDto, Guid>(mapper),
        ICommentOwnMutationService
    {
    }
}
