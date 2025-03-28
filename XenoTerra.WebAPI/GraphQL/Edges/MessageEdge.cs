using XenoTerra.DTOLayer.Dtos.MessageDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class MessageEdge
    {
        public ResultMessageWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
