using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations.Own
{
    public class AppUserOwnEdge
    {
        public ResultAppUserWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
