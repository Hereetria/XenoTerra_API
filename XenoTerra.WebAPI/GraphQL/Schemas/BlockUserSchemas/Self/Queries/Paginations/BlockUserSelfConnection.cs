using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Queries.Paginations
{
    public class BlockUserSelfConnection(
        IReadOnlyList<Edge<ResultBlockUserWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultBlockUserWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }


}
