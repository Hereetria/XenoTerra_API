using XenoTerra.DTOLayer.Dtos.MessageDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Queries.Paginations.Own
{
    public class MessageOwnEdge
    {
        public ResultMessageWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
