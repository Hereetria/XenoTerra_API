using AutoMapper;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.ReportCommentMutationServices
{
    public class ReportCommentOwnMutationService(IMapper mapper)
        : MutationService<ReportComment, ResultReportCommentOwnDto, CreateReportCommentOwnDto, UpdateReportCommentOwnDto, Guid>(mapper),
        IReportCommentOwnMutationService
    {
    }
}
