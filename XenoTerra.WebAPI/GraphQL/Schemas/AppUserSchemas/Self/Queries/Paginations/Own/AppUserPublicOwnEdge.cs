using XenoTerra.DTOLayer.Dtos.AppUserDtos.Own.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations.Own
{
    public class AppUserPublicOwnEdge
    {
        public ResultAppUserWithRelationsPublicDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
