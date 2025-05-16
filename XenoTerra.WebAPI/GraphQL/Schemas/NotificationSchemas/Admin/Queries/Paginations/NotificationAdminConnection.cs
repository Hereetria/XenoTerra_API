using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Queries.Paginations
{
    public class NotificationAdminConnection(
        IReadOnlyList<Edge<ResultNotificationWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultNotificationWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
