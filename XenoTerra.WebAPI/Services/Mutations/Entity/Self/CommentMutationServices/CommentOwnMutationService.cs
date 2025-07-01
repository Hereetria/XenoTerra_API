using AutoMapper;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.CommentMutationServices
{
    public class CommentOwnMutationService(IMapper mapper)
        : MutationService<Comment, ResultCommentOwnDto, CreateCommentOwnDto, UpdateCommentOwnDto, Guid>(mapper),
        ICommentOwnMutationService
    {
    }
}
