using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Queries.Paginations
{
    public class UserSettingAdminEdge
    {
        public ResultUserSettingWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
