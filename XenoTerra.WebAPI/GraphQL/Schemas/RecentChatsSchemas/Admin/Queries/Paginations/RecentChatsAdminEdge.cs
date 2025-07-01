using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Queries.Paginations
{
    public class RecentChatsAdminEdge
    {
        public ResultRecentChatsWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
