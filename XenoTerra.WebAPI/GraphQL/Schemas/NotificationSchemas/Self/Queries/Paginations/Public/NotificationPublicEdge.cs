using XenoTerra.DTOLayer.Dtos.NotificationAdminDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries.Paginations.Public
{
    public class NotificationPublicEdge
    {
        public ResultNotificationPublicDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
