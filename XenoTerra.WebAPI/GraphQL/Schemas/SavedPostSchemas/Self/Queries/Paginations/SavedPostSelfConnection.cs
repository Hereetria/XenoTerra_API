using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Queries.Paginations
{
    public class SavedPostSelfConnection(
        IReadOnlyList<Edge<ResultSavedPostWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultSavedPostWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
