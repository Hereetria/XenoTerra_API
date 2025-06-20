using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.BlockUserAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Queries.Paginations
{
    public class BlockUserAdminConnection(
        IReadOnlyList<Edge<ResultBlockUserWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultBlockUserWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }


}
