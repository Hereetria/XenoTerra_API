using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Admin;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.ReportStoryAdminMutationServices
{
    public interface IReportStoryAdminMutationService : IMutationService<ReportStory, ResultReportStoryAdminDto, CreateReportStoryAdminDto, UpdateReportStoryAdminDto, Guid>
    {
    }
}