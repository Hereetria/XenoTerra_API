

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.MediaServices
{
    
    public class MediaServiceDAL : GenericRepositoryDAL<Media, ResultMediaDto, ResultMediaWithRelationsDto, CreateMediaDto, UpdateMediaDto, Guid>, IMediaServiceDAL

    {

        public MediaServiceDAL(Context context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}