using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.MediaDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Queries.Paginations
{
    public class MediaConnection(
        IReadOnlyList<Edge<ResultMediaWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultMediaWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
