using XenoTerra.DTOLayer.Dtos.AppUserDtos.Own.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations.Own
{
    public class AppUserOwnOwnEdge
    {
        public ResultAppUserWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
