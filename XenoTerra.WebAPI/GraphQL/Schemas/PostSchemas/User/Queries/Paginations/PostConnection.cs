using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.PostDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries.Paginations
{
    public class PostConnection(
        IReadOnlyList<Edge<ResultPostWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultPostWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
