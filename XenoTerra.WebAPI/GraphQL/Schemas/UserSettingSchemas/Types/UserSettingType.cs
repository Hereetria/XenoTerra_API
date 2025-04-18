using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Types
{
    public class UserWithRelationsType : ObjectType<ResultUserWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultUserWithRelations");
        }
    }
}
