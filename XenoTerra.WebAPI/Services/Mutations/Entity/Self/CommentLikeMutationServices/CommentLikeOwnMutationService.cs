using AutoMapper;
using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.CommentLikeMutationServices
{
    public class CommentLikeOwnMutationService(IMapper mapper)
        : MutationService<CommentLike, ResultCommentLikeOwnDto, CreateCommentLikeOwnDto, UpdateCommentLikeOwnDto, Guid>(mapper),
        ICommentLikeOwnMutationService
    {
    }
}
