using AutoMapper;
using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.ReportPostMutationServices
{
    public class ReportPostOwnMutationService(IMapper mapper)
        : MutationService<ReportPost, ResultReportPostOwnDto, CreateReportPostOwnDto, UpdateReportPostOwnDto, Guid>(mapper),
        IReportPostOwnMutationService
    {
    }
}
