using XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.ReportCommentMutationServices
{
    public interface IReportCommentOwnMutationService : IMutationService<ReportComment, ResultReportCommentOwnDto, CreateReportCommentOwnDto, UpdateReportCommentOwnDto, Guid>
    {
    }
}
