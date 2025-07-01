using XenoTerra.DTOLayer.Dtos.ReportStoryDtos;
using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.ReportStorySelfMutationServices
{
    public interface IReportStoryOwnMutationService : IMutationService<ReportStory, ResultReportStoryOwnDto, CreateReportStoryOwnDto, UpdateReportStoryOwnDto, Guid>
    {
    }
}
