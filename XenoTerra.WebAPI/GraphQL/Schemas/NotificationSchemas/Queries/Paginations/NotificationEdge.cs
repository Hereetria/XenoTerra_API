using XenoTerra.DTOLayer.Dtos.NotificationDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Queries.Paginations
{
    public class NotificationEdge
    {
        public ResultNotificationWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
