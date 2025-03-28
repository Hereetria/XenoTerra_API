using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.StoryHighlightQueryServices
{
    public class StoryHighlightQueryService : QueryService<StoryHighlight, Guid>, IStoryHighlightQueryService
    {
        public StoryHighlightQueryService(IReadService<StoryHighlight, Guid> readService)
            : base(readService) { }
    }
}
