using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.CommentMutationServices
{
    public interface ICommentMutationService : IMutationService<Comment, ResultCommentDto, CreateCommentDto, UpdateCommentDto, Guid>
    {
    }
}
