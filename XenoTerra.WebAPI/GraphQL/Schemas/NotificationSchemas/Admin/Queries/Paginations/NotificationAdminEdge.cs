using XenoTerra.DTOLayer.Dtos.NotificationAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Queries.Paginations
{
    public class NotificationAdminEdge
    {
        public ResultNotificationWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
