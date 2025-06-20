using XenoTerra.DTOLayer.Dtos.ReportStoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.ReportStoryOwnMutationServices
{
    public interface IReportStoryOwnMutationService : IMutationService<ReportStory, ResultReportStoryOwnDto, CreateReportStoryOwnDto, UpdateReportStoryOwnDto, Guid>
    {
    }
}
