using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.ReportCommentQueryServices
{
    public class ReportCommentQueryService : BaseQueryService<ReportComment, ResultReportCommentDto, Guid>, IReportCommentQueryService
    {
        public ReportCommentQueryService(IReadService<ReportComment, Guid> readService, IMapper mapper)
            : base(readService, mapper) { }
    }
}
