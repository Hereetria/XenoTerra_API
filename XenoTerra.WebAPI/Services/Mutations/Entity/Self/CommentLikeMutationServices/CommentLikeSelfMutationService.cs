using AutoMapper;
using XenoTerra.DTOLayer.Dtos.CommentLikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.CommentLikeMutationServices
{
    public class CommentLikeSelfMutationService(IMapper mapper)
        : MutationService<CommentLike, ResultCommentLikeDto, CreateCommentLikeDto, UpdateCommentLikeDto, Guid>(mapper),
        ICommentLikeSelfMutationService
    {
    }
}
