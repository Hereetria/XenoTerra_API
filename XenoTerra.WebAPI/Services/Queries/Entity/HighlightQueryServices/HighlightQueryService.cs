using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.HighlightQueryServices
{
    public class HighlightQueryService : QueryService<Highlight, Guid>, IHighlightQueryService
    {
        public HighlightQueryService(IReadService<Highlight, Guid> readService)
            : base(readService) { }
    }
}
