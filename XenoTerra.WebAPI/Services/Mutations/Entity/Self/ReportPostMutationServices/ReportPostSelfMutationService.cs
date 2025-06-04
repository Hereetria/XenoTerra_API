using AutoMapper;
using XenoTerra.DTOLayer.Dtos.ReportPostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.ReportPostMutationServices
{
    public class ReportPostSelfMutationService(IMapper mapper)
        : MutationService<ReportPost, ResultReportPostDto, CreateReportPostDto, UpdateReportPostDto, Guid>(mapper),
        IReportPostSelfMutationService
    {
    }
}
