using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.CommentServices;
using XenoTerra.DTOLayer.Dtos.CommentDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.Comment
{
    public class CommentQuery
    {
        [UseProjection]
        public IQueryable<ResultCommentDto> GetComments(List<Guid>? ids, [Service] ICommentServiceBLL service)
            => ids != null && ids.Any() ? service.GetByIdsQuerable(ids) : service.GetByIdsQuerable(service.GetAllIdsAsync().Result);

        //[UseProjection]
        //[GraphQLDescription("Get Comment by ID")]
        //public IQueryable<ResultCommentByIdDto> GetCommentById(Guid id, [Service] ICommentServiceBLL commentServiceBLL)
        //{
        //    var result = commentServiceBLL.GetByIdQuerable(id);
        //    if (result == null)
        //    {
        //        throw new Exception($"Comment with ID {id} not found");
        //    }
        //    return result;
        //}
    }
}
