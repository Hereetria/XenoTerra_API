using XenoTerra.DTOLayer.Dtos.ReportPostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.ReportPostMutationServices
{
    public interface IReportPostSelfMutationService : IMutationService<ReportPost, ResultReportPostDto, CreateReportPostDto, UpdateReportPostDto, Guid>
    {
    }
}
