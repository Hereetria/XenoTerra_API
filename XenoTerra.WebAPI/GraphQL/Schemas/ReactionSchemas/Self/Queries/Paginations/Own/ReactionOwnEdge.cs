using XenoTerra.DTOLayer.Dtos.ReactionDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Queries.Paginations.Own
{
    public class ReactionOwnEdge
    {
        public ResultReactionWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
