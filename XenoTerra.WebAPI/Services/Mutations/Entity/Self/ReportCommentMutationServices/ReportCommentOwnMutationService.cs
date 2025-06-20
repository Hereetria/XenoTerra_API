using AutoMapper;
using XenoTerra.DTOLayer.Dtos.ReportCommentAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.ReportCommentMutationServices
{
    public class ReportCommentOwnMutationService(IMapper mapper)
        : MutationService<ReportComment, ResultReportCommentOwnDto, CreateReportCommentOwnDto, UpdateReportCommentOwnDto, Guid>(mapper),
        IReportCommentOwnMutationService
    {
    }
}
