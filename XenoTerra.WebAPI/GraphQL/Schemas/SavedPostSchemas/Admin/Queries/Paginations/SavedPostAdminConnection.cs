using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Queries.Paginations
{
    public class SavedPostAdminConnection(
        IReadOnlyList<Edge<ResultSavedPostWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultSavedPostWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
