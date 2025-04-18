using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Queries.Paginations
{
    public class RecentChatsEdge
    {
        public ResultRecentChatsWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
