using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.MediaService
{
    public class MediaReadService : ReadService<Media, ResultMediaWithRelationsDto, Guid>, IMediaReadService
    {
        public MediaReadService(IReadRepository<Media, Guid> repository, IMapper mapper, DataAccessLayer.Utils.SelectorExpressionProvider<Media, ResultMediaWithRelationsDto> selectorExpressionProvider) : base(repository, mapper, selectorExpressionProvider)
        {
        }
    }

}
