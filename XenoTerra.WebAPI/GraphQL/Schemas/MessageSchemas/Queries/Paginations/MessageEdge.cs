using XenoTerra.DTOLayer.Dtos.MessageDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Queries.Paginations
{
    public class MessageEdge
    {
        public ResultMessageWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
