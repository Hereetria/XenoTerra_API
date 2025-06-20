using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.SavedPostAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Queries.Paginations
{
    public class SavedPostAdminConnection(
        IReadOnlyList<Edge<ResultSavedPostWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultSavedPostWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
