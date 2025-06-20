using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.ReportCommentAdminDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Queries.Paginations.Own
{
    public class ReportCommentOwnConnection(
        IReadOnlyList<Edge<ResultReportCommentWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultReportCommentWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
