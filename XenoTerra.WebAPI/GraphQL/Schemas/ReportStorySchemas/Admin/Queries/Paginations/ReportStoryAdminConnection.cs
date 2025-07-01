using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Queries.Paginations
{
    public class ReportStoryAdminConnection(
        IReadOnlyList<Edge<ResultReportStoryWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultReportStoryWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
