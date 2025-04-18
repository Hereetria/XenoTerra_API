using XenoTerra.DTOLayer.Dtos.UserSettingDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Types
{
    public class UserSettingWithRelationsType : ObjectType<ResultUserSettingWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserSettingWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultUserSettingWithRelations");
        }
    }
}
