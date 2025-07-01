using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Types.Self.Own
{
    public class UserSettingOwnType : ObjectType<ResultUserSettingOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserSettingOwnDto> descriptor)
        {
            descriptor.Name("ResultUserSettingOwn");
        }
    }
}
