using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Queries.Paginations.Own
{
    public class RecentChatsOwnEdge
    {
        public ResultRecentChatsWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
