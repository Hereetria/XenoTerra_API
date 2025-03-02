using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.CommentServices;
using XenoTerra.DTOLayer.Dtos.CommentDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.Comment
{
    public class CommentQuery
    {
        [UseProjection]
        [GraphQLDescription("Get all Comments")]
        public IQueryable<ResultCommentDto> GetAllComments([Service] ICommentServiceBLL commentServiceBLL)
        {
            return commentServiceBLL.GetAllQuerable();
        }

        [UseProjection]
        [GraphQLDescription("Get Comment by ID")]
        public IQueryable<ResultCommentByIdDto> GetCommentById(Guid id, [Service] ICommentServiceBLL commentServiceBLL)
        {
            var result = commentServiceBLL.GetByIdQuerable(id);
            if (result == null)
            {
                throw new Exception($"Comment with ID {id} not found");
            }
            return result;
        }
    }
}
