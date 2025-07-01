using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Types.Self.Own
{
    public class UserSettingWithRelationsOwnType : ObjectType<ResultUserSettingWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserSettingWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultUserSettingWithRelationsOwn");
        }
    }
}
