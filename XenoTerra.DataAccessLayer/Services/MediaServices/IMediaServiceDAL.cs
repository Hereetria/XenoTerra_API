
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Services.MediaServices
{
    
    public interface IMediaServiceDAL : IGenericRepositoryDAL<Media, ResultMediaDto, ResultMediaByIdDto ,CreateMediaDto, UpdateMediaDto, Guid>

    {

    }
}