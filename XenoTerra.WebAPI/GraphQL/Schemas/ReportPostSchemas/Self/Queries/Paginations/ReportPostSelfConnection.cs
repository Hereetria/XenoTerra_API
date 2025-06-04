using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.ReportPostDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Queries.Paginations
{
    public class ReportPostSelfConnection(
        IReadOnlyList<Edge<ResultReportPostWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultReportPostWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
