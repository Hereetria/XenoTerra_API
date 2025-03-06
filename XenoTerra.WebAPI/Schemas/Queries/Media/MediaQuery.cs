using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.MediaServices;
using XenoTerra.DTOLayer.Dtos.MediaDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.Media
{
    public class MediaQuery
    {
        [UseProjection]
        public IQueryable<ResultMediaDto> GetMedia(List<Guid>? ids, [Service] IMediaServiceBLL service)
    => ids != null && ids.Any() ? service.GetByIdsQuerable(ids) : service.GetByIdsQuerable(service.GetAllIdsAsync().Result);
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
