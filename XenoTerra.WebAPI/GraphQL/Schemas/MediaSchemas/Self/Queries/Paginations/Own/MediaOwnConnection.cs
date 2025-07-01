using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.MediaDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Queries.Paginations.Own
{
    public class MediaOwnConnection(
        IReadOnlyList<Edge<ResultMediaWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultMediaWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
