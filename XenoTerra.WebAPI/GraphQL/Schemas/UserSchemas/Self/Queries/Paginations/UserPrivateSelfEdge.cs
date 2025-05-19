using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Queries.Paginations
{
    public class UserPrivateSelfEdge
    {
        public ResultUserWithRelationsPrivateDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
