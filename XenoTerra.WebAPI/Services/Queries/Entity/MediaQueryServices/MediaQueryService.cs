using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.MediaQueryServices
{
    public class MediaQueryService : BaseQueryService<Media, ResultMediaDto, Guid>, IMediaQueryService
    {
        public MediaQueryService(IReadService<Media, Guid> readService, IMapper mapper)
            : base(readService, mapper) { }
    }
}
