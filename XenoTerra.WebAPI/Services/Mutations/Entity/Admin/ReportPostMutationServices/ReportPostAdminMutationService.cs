using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.ReportPostAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.ReportPostMutationServices
{
    public class ReportPostAdminMutationService(IMapper mapper)
        : MutationService<ReportPost, ResultReportPostAdminDto, CreateReportPostAdminDto, UpdateReportPostAdminDto, Guid>(mapper),
        IReportPostAdminMutationService
    {
    }
}