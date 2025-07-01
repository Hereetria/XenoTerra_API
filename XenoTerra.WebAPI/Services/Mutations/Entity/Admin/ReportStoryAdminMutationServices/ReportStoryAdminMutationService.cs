using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Admin;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.ReportStoryAdminMutationServices
{
    public class ReportStoryAdminMutationService(IMapper mapper) 
        : MutationService<ReportStory, ResultReportStoryAdminDto, CreateReportStoryAdminDto, UpdateReportStoryAdminDto, Guid>(mapper),
        IReportStoryAdminMutationService
    {
    }
}