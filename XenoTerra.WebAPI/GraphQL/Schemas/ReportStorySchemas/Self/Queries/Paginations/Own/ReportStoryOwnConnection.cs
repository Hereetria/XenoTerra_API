using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Queries.Paginations.Own
{
    public class ReportStoryOwnConnection(
        IReadOnlyList<Edge<ResultReportStoryWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultReportStoryWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
