using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Types
{
    public class UserWithRelationsType : ObjectType<ResultUserWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultUserWithRelations");
        }
    }
}
