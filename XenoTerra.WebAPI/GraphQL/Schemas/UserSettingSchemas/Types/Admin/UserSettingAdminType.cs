using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Types.Admin
{
    public class UserSettingAdminType : ObjectType<ResultUserSettingAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserSettingAdminDto> descriptor)
        {
            descriptor.Name("ResultUserSettingAdmin");
        }
    }
}
