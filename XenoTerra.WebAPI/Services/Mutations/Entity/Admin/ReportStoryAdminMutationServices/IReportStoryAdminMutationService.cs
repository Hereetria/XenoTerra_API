using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.ReportStoryAdminDtos.Admin;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.ReportStoryAdminMutationServices
{
    public interface IReportStoryAdminMutationService : IMutationService<ReportStory, ResultReportStoryAdminDto, CreateReportStoryAdminDto, UpdateReportStoryAdminDto, Guid>
    {
    }
}