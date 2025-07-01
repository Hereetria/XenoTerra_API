using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Queries.Paginations.Public
{
    public class UserPostTagPublicEdge
    {
        public ResultUserPostTagWithRelationsPublicDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
