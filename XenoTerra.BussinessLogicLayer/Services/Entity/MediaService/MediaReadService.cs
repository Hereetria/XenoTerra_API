using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.MediaService
{
    public class MediaReadService(IReadRepository<Media, Guid> readRepository) : ReadService<Media, Guid>(readRepository), IMediaReadService
    {
    }
}
