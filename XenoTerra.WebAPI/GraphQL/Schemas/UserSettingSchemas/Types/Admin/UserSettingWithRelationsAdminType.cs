using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Types.Admin
{
    public class UserSettingWithRelationsAdminType : ObjectType<ResultUserSettingWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserSettingWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultUserSettingWithRelationsAdmin");
        }
    }
}
