using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.ReportCommentMutationServices
{
    public interface IReportCommentAdminMutationService : IMutationService<ReportComment, ResultReportCommentDto, CreateReportCommentDto, UpdateReportCommentDto, Guid>
    {
    }
}
