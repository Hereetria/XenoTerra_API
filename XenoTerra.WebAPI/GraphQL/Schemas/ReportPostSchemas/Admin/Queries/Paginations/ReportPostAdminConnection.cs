using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.ReportPostAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Queries.Paginations
{
    public class ReportPostAdminConnection(
        IReadOnlyList<Edge<ResultReportPostWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultReportPostWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
