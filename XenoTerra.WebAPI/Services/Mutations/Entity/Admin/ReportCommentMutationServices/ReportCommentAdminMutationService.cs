using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.ReportCommentAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.ReportCommentMutationServices
{
    public class ReportCommentAdminMutationService(IMapper mapper)
        : MutationService<ReportComment, ResultReportCommentAdminDto, CreateReportCommentAdminDto, UpdateReportCommentAdminDto, Guid>(mapper),
        IReportCommentAdminMutationService
    {
    }
}