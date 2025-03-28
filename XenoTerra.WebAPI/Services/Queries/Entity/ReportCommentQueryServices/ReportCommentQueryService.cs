using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.ReportCommentQueryServices
{

    public class ReportCommentQueryService : QueryService<ReportComment, Guid>, IReportCommentQueryService
    {
        public ReportCommentQueryService(IReadService<ReportComment, Guid> readService)
            : base(readService)
        {
        }
    }
}
