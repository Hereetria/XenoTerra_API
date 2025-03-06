
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.BussinessLogicLayer.Services.MediaServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
namespace XenoTerra.BussinessLogicLayer.Services.MediaServices
{
     public class MediaServiceBLL : GenericRepositoryBLL<Media, ResultMediaDto, CreateMediaDto, UpdateMediaDto, Guid>, IMediaServiceBLL
    {
        public MediaServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory)
            : base(repositoryDALFactory)
        {
        }
    }
}