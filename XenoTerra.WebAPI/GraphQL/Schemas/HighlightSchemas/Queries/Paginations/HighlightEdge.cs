using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Queries.Paginations
{
    public class HighlightEdge
    {
        public ResultHighlightWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
