using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.LikeServices;
using XenoTerra.DTOLayer.Dtos.LikeDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.Like
{
    public class LikeQuery
    {
        [UseProjection]
        public IQueryable<ResultLikeWithRelationsDto> GetLikes(
        List<Guid>? ids,
        [Service] ILikeServiceBLL service
    ) => service.GetByIdsQuerableWithRelations(ids ?? service.GetAllIdsAsync().Result);

        //[UseProjection]
        //[GraphQLDescription("Get all Likes")]
        //public IQueryable<ResultLikeDto> GetAllLikes([Service] ILikeServiceBLL likeServiceBLL)
        //{
        //    return likeServiceBLL.GetAllQuerable();
        //}

        //[UseProjection]
        //[GraphQLDescription("Get Like by ID")]
        //public IQueryable<ResultLikeByIdDto> GetLikeById(Guid id, [Service] ILikeServiceBLL likeServiceBLL)
        //{
        //    var result = likeServiceBLL.GetByIdQuerable(id);
        //    if (result == null)
        //    {
        //        throw new Exception($"Like with ID {id} not found");
        //    }
        //    return result;
        //}
    }
}
