using AutoMapper;
using XenoTerra.DTOLayer.Dtos.ReportPostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.ReportPostMutationServices
{
    public class ReportPostAdminMutationService(IMapper mapper)
        : MutationService<ReportPost, ResultReportPostDto, CreateReportPostDto, UpdateReportPostDto, Guid>(mapper),
        IReportPostAdminMutationService
    {
    }
}
