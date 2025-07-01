using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.CommentMutationServices
{
    public class CommentAdminMutationService(IMapper mapper)
        : MutationService<Comment, ResultCommentAdminDto, CreateCommentAdminDto, UpdateCommentAdminDto, Guid>(mapper),
        ICommentAdminMutationService
    {
    }
}