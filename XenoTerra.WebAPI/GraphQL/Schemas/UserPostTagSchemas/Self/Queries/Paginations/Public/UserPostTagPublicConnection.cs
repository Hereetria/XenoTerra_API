using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Queries.Paginations.Public
{
    public class UserPostTagPublicConnection(
        IReadOnlyList<Edge<ResultUserPostTagWithRelationsPublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultUserPostTagWithRelationsPublicDto>(edges, pageInfo, totalCount)
    {
    }
}
