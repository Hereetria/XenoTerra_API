using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Queries.Paginations.Own
{
    public class ReportPostOwnConnection(
        IReadOnlyList<Edge<ResultReportPostWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultReportPostWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
