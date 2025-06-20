using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.ViewStoryQueryServices
{
    public class ViewStoryQueryService : QueryService<ViewStory, Guid>, IViewStoryQueryService
    {
        public ViewStoryQueryService(IReadService<ViewStory, Guid> readService)
            : base(readService)
        {
        }
    }
}
