using XenoTerra.DTOLayer.Dtos.ReportPostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.ReportPostMutationServices
{
    public interface IReportPostAdminMutationService : IMutationService<ReportPost, ResultReportPostDto, CreateReportPostDto, UpdateReportPostDto, Guid>
    {
    }
}
