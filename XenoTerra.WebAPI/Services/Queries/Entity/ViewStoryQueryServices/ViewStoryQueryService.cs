using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.ViewStoryQueryServices
{
    public class ViewStoryQueryService : QueryService<ViewStory, ResultViewStoryWithRelationsDto, Guid>, IViewStoryQueryService
    {
        public ViewStoryQueryService(IReadService<ViewStory, ResultViewStoryWithRelationsDto, Guid> readService, IMapper mapper)
            : base(readService, mapper)
        {
        }
    }
}
