using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Paginations.Public
{
    public class PostPublicConnection(
        IReadOnlyList<Edge<ResultPostWithRelationsPublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultPostWithRelationsPublicDto>(edges, pageInfo, totalCount)
    {
    }
}
