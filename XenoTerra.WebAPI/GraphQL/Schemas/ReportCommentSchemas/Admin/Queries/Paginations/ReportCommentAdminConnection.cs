using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries.Paginations
{
    public class ReportCommentAdminConnection(
        IReadOnlyList<Edge<ResultReportCommentWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultReportCommentWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
