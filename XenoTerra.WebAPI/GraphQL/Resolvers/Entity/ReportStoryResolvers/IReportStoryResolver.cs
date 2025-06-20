using XenoTerra.DTOLayer.Dtos.ReportStoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;

namespace XenoTerra.WebAPI.GraphQL.Resolvers.Entity.ReportStoryResolvers
{
    public interface IReportStoryResolver : IEntityResolver<ReportStory, Guid>
    {
    }
}
