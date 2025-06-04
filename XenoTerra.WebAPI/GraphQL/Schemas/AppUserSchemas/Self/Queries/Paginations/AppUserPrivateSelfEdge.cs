using XenoTerra.DTOLayer.Dtos.AppUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations
{
    public class AppUserPrivateSelfEdge
    {
        public ResultAppUserWithRelationsPrivateDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
