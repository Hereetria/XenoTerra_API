using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.HighlightQueryServices
{
    public class HighlightQueryService : BaseQueryService<Highlight, ResultHighlightDto, Guid>, IHighlightQueryService
    {
        public HighlightQueryService(IReadService<Highlight, Guid> readService, IMapper mapper)
            : base(readService, mapper) { }
    }
}
