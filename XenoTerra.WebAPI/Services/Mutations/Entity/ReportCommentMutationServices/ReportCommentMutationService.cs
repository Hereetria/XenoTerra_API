using AutoMapper;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.ReportCommentMutationServices
{
    public class ReportCommentMutationService(IMapper mapper)
        : MutationService<ReportComment, ResultReportCommentDto, CreateReportCommentDto, UpdateReportCommentDto, Guid>(mapper),
        IReportCommentMutationService
    {
    }
}
