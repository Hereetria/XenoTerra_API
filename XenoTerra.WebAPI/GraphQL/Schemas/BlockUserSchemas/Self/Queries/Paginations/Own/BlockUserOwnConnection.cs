using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Queries.Paginations.Own
{
    public class BlockUserOwnConnection(
        IReadOnlyList<Edge<ResultBlockUserWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultBlockUserWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }


}
