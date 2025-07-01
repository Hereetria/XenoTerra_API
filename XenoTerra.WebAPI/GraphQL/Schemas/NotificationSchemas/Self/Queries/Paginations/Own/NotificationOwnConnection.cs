using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.NotificationDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries.Paginations.Own
{
    public class NotificationOwnConnection(
        IReadOnlyList<Edge<ResultNotificationWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultNotificationWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
