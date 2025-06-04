using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Queries.Paginations
{
    public class PostLikeAdminConnection(
        IReadOnlyList<Edge<ResultPostLikeWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultPostLikeWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
