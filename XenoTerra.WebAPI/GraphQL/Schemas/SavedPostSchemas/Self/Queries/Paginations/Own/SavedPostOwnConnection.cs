using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.SavedPostAdminDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Queries.Paginations.Own
{
    public class SavedPostOwnConnection(
        IReadOnlyList<Edge<ResultSavedPostWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultSavedPostWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
