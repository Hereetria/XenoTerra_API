using XenoTerra.DTOLayer.Dtos.ReactionDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class ReactionEdge
    {
        public ResultReactionWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
