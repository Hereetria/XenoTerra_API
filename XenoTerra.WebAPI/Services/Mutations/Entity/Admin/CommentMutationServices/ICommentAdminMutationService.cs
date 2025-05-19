using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.CommentMutationServices
{
    public interface ICommentAdminMutationService : IMutationService<Comment, ResultCommentDto, CreateCommentDto, UpdateCommentDto, Guid>
    {
    }
}
