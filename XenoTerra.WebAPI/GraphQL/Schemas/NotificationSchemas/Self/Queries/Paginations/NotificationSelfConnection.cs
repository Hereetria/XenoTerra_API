using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries.Paginations
{
    public class NotificationSelfConnection(
        IReadOnlyList<Edge<ResultNotificationWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultNotificationWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
