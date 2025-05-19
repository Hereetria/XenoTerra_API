using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.PostDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Paginations
{
    public class PostSelfConnection(
        IReadOnlyList<Edge<ResultPostWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultPostWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
