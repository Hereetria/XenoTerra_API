using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.ViewStoryQueryServices
{
    public interface IViewStoryQueryService : IBaseQueryService<ViewStory, ResultViewStoryDto, Guid> { }

}
