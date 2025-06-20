using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.NotificationAdminDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries.Paginations.Public
{
    public class NotificationPublicConnection(
        IReadOnlyList<Edge<ResultNotificationPublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultNotificationPublicDto>(edges, pageInfo, totalCount)
    {
    }
}
