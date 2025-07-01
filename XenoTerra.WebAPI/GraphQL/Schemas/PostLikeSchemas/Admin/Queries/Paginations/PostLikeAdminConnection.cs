using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Queries.Paginations
{
    public class PostLikeAdminConnection(
        IReadOnlyList<Edge<ResultPostLikeWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultPostLikeWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
