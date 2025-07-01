using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Paginations.Public
{
    public class HighlightPublicEdge
    {
        public ResultHighlightWithRelationsPublicDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
