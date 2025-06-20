using XenoTerra.DTOLayer.Dtos.NotificationAdminDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries.Paginations.Own
{
    public class NotificationOwnEdge
    {
        public ResultNotificationWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
