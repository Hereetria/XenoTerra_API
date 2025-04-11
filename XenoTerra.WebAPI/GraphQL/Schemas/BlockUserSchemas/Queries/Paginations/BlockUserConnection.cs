using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Queries.Paginations
{
    public class BlockUserConnection(
        IReadOnlyList<Edge<ResultBlockUserWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultBlockUserWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }


}
