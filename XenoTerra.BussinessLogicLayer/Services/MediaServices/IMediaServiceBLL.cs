
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.MediaServices
{
        public interface IMediaServiceBLL : IGenericRepositoryBLL<Media, ResultMediaDto, ResultMediaWithRelationsDto, CreateMediaDto, UpdateMediaDto, Guid>
    {

    }
}