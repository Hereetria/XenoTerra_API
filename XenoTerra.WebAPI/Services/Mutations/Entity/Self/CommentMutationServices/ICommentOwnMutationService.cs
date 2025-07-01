using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.CommentMutationServices
{
    public interface ICommentOwnMutationService : IMutationService<Comment, ResultCommentOwnDto, CreateCommentOwnDto, UpdateCommentOwnDto, Guid>
    {
    }
}
