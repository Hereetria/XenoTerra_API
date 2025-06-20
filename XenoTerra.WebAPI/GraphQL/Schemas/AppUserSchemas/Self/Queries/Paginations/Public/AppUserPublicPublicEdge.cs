using XenoTerra.DTOLayer.Dtos.AppUserDtos.Public.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations.Public
{
    public class AppUserPublicPublicEdge
    {
        public ResultAppUserPublicDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
