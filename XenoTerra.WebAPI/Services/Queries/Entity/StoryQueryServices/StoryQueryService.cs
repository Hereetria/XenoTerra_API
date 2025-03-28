using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.StoryQueryServices
{
    public class StoryQueryService : QueryService<Story, Guid>, IStoryQueryService
    {
        public StoryQueryService(IReadService<Story, Guid> readService)
            : base(readService)
        {
        }
    }

}
