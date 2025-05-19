using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.ReportCommentMutationServices
{
    public interface IReportCommentSelfMutationService : IMutationService<ReportComment, ResultReportCommentDto, CreateReportCommentDto, UpdateReportCommentDto, Guid>
    {
    }
}
