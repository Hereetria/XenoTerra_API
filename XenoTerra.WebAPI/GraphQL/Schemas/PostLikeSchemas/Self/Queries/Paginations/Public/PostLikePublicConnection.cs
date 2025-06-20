using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.PostLikeAdminDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Paginations.Public
{
    public class PostLikePublicConnection(
        IReadOnlyList<Edge<ResultPostLikePublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultPostLikePublicDto>(edges, pageInfo, totalCount)
    {
    }
}
