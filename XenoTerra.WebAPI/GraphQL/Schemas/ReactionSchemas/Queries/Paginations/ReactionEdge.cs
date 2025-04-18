using XenoTerra.DTOLayer.Dtos.ReactionDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Queries.Paginations
{
    public class ReactionEdge
    {
        public ResultReactionWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
