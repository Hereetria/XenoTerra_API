using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.ReportPostQueryServices
{

    public class ReportPostQueryService : QueryService<ReportPost, Guid>, IReportPostQueryService
    {
        public ReportPostQueryService(IReadService<ReportPost, Guid> readService)
            : base(readService)
        {
        }
    }
}
