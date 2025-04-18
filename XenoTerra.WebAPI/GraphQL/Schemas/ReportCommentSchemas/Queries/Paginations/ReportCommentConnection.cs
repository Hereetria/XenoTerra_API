using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Queries.Paginations
{
    public class ReportCommentConnection(
        IReadOnlyList<Edge<ResultReportCommentWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultReportCommentWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
