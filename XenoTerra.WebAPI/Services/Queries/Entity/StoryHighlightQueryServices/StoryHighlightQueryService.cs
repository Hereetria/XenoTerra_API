using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.StoryHighlightQueryServices
{
    public class StoryHighlightQueryService : QueryService<StoryHighlight, ResultStoryHighlightWithRelationsDto, Guid>, IStoryHighlightQueryService
    {
        public StoryHighlightQueryService(IReadService<StoryHighlight, ResultStoryHighlightWithRelationsDto, Guid> readService, IMapper mapper)
            : base(readService, mapper) { }
    }
}
