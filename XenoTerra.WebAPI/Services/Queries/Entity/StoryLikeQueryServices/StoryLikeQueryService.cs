using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.StoryLikeQueryServices
{
    public class StoryLikeQueryService : QueryService<StoryLike, Guid>, IStoryLikeQueryService
    {
        public StoryLikeQueryService(IReadService<StoryLike, Guid> readService)
            : base(readService)
        {
        }
    }
}
