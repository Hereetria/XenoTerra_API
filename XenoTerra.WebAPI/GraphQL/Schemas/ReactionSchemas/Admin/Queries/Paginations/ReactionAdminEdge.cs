using XenoTerra.DTOLayer.Dtos.ReactionDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Queries.Paginations
{
    public class ReactionAdminEdge
    {
        public ResultReactionWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
