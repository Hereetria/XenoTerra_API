using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.MediaDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Queries.Paginations
{
    public class MediaSelfConnection(
        IReadOnlyList<Edge<ResultMediaWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultMediaWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
