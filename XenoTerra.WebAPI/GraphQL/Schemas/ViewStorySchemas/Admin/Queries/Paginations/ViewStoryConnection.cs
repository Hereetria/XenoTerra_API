using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Queries.Paginations
{
    public class ViewStoryConnection(
        IReadOnlyList<Edge<ResultViewStoryWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultViewStoryWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
