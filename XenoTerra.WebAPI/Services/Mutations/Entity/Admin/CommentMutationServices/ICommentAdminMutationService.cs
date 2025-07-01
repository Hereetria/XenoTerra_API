using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.CommentMutationServices
{
    public interface ICommentAdminMutationService : IMutationService<Comment, ResultCommentAdminDto, CreateCommentAdminDto, UpdateCommentAdminDto, Guid>
    {
    }
}