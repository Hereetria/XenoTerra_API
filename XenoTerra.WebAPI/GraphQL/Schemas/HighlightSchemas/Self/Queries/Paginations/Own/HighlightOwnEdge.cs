using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Paginations.Own
{
    public class HighlightOwnEdge
    {
        public ResultHighlightWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
