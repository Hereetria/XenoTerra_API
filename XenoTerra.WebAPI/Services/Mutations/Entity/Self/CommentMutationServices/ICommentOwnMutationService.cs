using XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.CommentMutationServices
{
    public interface ICommentOwnMutationService : IMutationService<Comment, ResultCommentOwnDto, CreateCommentOwnDto, UpdateCommentOwnDto, Guid>
    {
    }
}
