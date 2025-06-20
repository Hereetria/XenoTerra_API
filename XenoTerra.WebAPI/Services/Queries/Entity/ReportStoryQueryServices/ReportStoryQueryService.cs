using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.ReportStoryQueryServices
{
    public class ReportStoryQueryService : QueryService<ReportStory, Guid>, IReportStoryQueryService
    {
        public ReportStoryQueryService(IReadService<ReportStory, Guid> readService)
            : base(readService)
        {
        }
    }
}
