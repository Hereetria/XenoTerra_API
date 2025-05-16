using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Queries.Paginations
{
    public class BlockUserAdminConnection(
        IReadOnlyList<Edge<ResultBlockUserWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultBlockUserWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }


}
