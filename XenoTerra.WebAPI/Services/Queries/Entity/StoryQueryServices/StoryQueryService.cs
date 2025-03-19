using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.StoryQueryServices
{
    public class StoryQueryService : QueryService<Story, ResultStoryWithRelationsDto, Guid>, IStoryQueryService
    {
        public StoryQueryService(IReadService<Story, ResultStoryWithRelationsDto, Guid> readService, IMapper mapper)
            : base(readService, mapper)
        {
        }
    }

}
