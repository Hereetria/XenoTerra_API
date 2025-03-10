using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Write;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.MediaService
{

    public class MediaWriteService : WriteService<Media, ResultMediaDto, CreateMediaDto, UpdateMediaDto, Guid>, IMediaWriteService
    {
        public MediaWriteService(IWriteRepository<Media, Guid> repository, IMapper mapper, SelectorExpressionProvider<Media, ResultMediaDto> selectorExpressionProvider)
            : base(repository, mapper, selectorExpressionProvider) { }
    }
}
