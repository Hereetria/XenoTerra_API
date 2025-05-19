using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Types
{
    public class UserWithRelationsType : ObjectType<ResultUserWithRelationsPrivateDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserWithRelationsPrivateDto> descriptor)
        {
            descriptor.Name("ResultUserWithRelations");
        }
    }
}
