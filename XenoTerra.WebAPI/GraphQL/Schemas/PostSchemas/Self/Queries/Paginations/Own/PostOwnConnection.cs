using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.PostAdminDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Paginations.Own
{
    public class PostOwnConnection(
        IReadOnlyList<Edge<ResultPostWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultPostWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
