using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.ReportPostMutationServices
{
    public interface IReportPostAdminMutationService : IMutationService<ReportPost, ResultReportPostAdminDto, CreateReportPostAdminDto, UpdateReportPostAdminDto, Guid>
    {
    }
}