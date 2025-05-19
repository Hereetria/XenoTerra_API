using XenoTerra.DTOLayer.Dtos.UserSettingDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Queries.Paginations
{
    public class UserSettingSelfEdge
    {
        public ResultUserSettingWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
