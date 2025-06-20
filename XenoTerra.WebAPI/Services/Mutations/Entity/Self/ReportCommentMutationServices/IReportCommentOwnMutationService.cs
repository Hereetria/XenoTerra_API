using XenoTerra.DTOLayer.Dtos.ReportCommentAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.ReportCommentMutationServices
{
    public interface IReportCommentOwnMutationService : IMutationService<ReportComment, ResultReportCommentOwnDto, CreateReportCommentOwnDto, UpdateReportCommentOwnDto, Guid>
    {
    }
}
