
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Services.CommentServices
{
    
    public interface ICommentServiceDAL : IGenericRepositoryDAL<Comment, ResultCommentDto, ResultCommentByIdDto ,CreateCommentDto, UpdateCommentDto, Guid>

    {

    }
}