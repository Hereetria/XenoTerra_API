using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.StoryQueryServices
{
    public interface IStoryQueryService : IQueryService<Story, Guid>
    {
    }

}
