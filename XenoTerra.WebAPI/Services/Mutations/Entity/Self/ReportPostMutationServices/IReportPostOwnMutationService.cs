using XenoTerra.DTOLayer.Dtos.ReportPostAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.ReportPostMutationServices
{
    public interface IReportPostOwnMutationService : IMutationService<ReportPost, ResultReportPostOwnDto, CreateReportPostOwnDto, UpdateReportPostOwnDto, Guid>
    {
    }
}
