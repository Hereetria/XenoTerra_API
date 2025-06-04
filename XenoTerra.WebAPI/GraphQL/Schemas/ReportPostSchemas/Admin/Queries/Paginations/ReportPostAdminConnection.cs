using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.ReportPostDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Queries.Paginations
{
    public class ReportPostAdminConnection(
        IReadOnlyList<Edge<ResultReportPostWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultReportPostWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
