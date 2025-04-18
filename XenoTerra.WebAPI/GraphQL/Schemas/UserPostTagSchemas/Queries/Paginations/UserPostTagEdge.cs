using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Queries.Paginations
{
    public class UserPostTagEdge
    {
        public ResultUserPostTagWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
