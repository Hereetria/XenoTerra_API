using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Queries.Paginations
{
    public class UserPostTagConnection(
        IReadOnlyList<Edge<ResultUserPostTagWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultUserPostTagWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
