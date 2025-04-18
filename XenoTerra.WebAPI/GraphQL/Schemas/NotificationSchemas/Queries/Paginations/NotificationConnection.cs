using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Queries.Paginations
{
    public class NotificationConnection(
        IReadOnlyList<Edge<ResultNotificationWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultNotificationWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
