using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.StoryHighlightQueryServices
{

    public interface IStoryHighlightQueryService : IBaseQueryService<StoryHighlight, ResultStoryHighlightDto, Guid> { }

}
