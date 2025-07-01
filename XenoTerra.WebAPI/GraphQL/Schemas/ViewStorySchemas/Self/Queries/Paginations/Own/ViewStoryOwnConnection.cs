using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Queries.Paginations.Own
{
    public class ViewStoryOwnConnection(
        IReadOnlyList<Edge<ResultViewStoryWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultViewStoryWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
