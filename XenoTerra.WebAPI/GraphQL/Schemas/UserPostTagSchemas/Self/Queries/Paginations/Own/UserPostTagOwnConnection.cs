using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Queries.Paginations.Own
{
    public class UserPostTagOwnConnection(
        IReadOnlyList<Edge<ResultUserPostTagWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultUserPostTagWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
