namespace XenoTerra.WebAPI.Schemas.Queries.Like
{
    public class LikeQuery
    {
        public string GetRandomData()
        {
            return "Default data to prevent query class from being empty.";
        }

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
