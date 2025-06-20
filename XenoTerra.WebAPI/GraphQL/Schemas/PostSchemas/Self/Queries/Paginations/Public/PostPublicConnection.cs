using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.PostAdminDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Paginations.Public
{
    public class PostPublicConnection(
        IReadOnlyList<Edge<ResultPostPublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultPostPublicDto>(edges, pageInfo, totalCount)
    {
    }
}
