using AutoMapper;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.CommentMutationServices
{
    public class CommentSelfMutationService(IMapper mapper)
        : MutationService<Comment, ResultCommentDto, CreateCommentDto, UpdateCommentDto, Guid>(mapper),
        ICommentSelfMutationService
    {
    }
}
