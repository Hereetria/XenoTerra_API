using AutoMapper;
using XenoTerra.DTOLayer.Dtos.ReportStoryDtos;
using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.ReportStoryAdminMutationServices;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.ReportStorySelfMutationServices
{
    public class ReportStoryOwnMutationService(IMapper mapper) 
        : MutationService<ReportStory, ResultReportStoryOwnDto, CreateReportStoryOwnDto, UpdateReportStoryOwnDto, Guid>(mapper),
        IReportStoryOwnMutationService
    {
    }
}
