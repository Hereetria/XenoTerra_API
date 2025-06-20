using XenoTerra.DTOLayer.Dtos.UserSettingAdminDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Queries.Paginations.Own
{
    public class UserSettingOwnEdge
    {
        public ResultUserSettingWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
