using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Types
{
    public class UserType : ObjectType<ResultUserDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserDto> descriptor)
        {
            descriptor.Name("ResultUser");
        }
    }
}
