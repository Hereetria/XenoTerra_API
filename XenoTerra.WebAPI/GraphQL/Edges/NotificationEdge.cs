using XenoTerra.DTOLayer.Dtos.NotificationDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class NotificationEdge
    {
        public ResultNotificationWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
