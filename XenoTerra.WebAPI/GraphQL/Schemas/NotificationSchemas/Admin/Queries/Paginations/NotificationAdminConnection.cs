using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.NotificationAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Queries.Paginations
{
    public class NotificationAdminConnection(
        IReadOnlyList<Edge<ResultNotificationWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultNotificationWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
