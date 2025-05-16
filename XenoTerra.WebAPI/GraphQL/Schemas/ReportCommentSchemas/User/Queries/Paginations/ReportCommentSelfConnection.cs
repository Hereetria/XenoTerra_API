using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries.Paginations
{
    public class ReportCommentSelfConnection(
        IReadOnlyList<Edge<ResultReportCommentWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultReportCommentWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
