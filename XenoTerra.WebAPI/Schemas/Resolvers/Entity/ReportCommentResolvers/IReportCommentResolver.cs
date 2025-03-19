using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.ReportCommentResolvers
{
    public interface IReportCommentResolver : IEntityResolver<ReportComment, ResultReportCommentWithRelationsDto, Guid>
    {
    }
}
