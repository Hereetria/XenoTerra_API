using HotChocolate;
using XenoTerra.DTOLayer.Dtos.MediaDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.MediaQueries
{
    public class MediaQuery
    {
        public string GetRandomData()
        {
            return "Default data to prevent query class from being empty.";
        }

        //[UseProjection]
        //[GraphQLDescription("Get all Media")]
        //public IQueryable<ResultMediaDto> GetAllMedia([Service] IMediaServiceBLL mediaServiceBLL)
        //{
        //    return mediaServiceBLL.GetAllQuerable();
        //}

        //[UseProjection]
        //[GraphQLDescription("Get Media by ID")]
        //public IQueryable<ResultMediaByIdDto> GetMediaById(Guid id, [Service] IMediaServiceBLL mediaServiceBLL)
        //{
        //    var result = mediaServiceBLL.GetByIdQuerable(id);
        //    if (result == null)
        //    {
        //        throw new Exception($"Media with ID {id} not found");
        //    }
        //    return result;
        //}
    }
}
