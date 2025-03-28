using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class RecentChatsEdge
    {
        public ResultRecentChatsWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
