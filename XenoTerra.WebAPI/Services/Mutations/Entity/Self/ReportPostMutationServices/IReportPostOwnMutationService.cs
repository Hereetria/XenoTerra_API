using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.ReportPostMutationServices
{
    public interface IReportPostOwnMutationService : IMutationService<ReportPost, ResultReportPostOwnDto, CreateReportPostOwnDto, UpdateReportPostOwnDto, Guid>
    {
    }
}
