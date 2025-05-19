using XenoTerra.DTOLayer.Dtos.UserSettingDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Types
{
    public class UserSettingType : ObjectType<ResultUserSettingDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserSettingDto> descriptor)
        {
            descriptor.Name("ResultUserSetting");
        }
    }
}
