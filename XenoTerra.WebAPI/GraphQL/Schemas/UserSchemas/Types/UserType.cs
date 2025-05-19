using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Types
{
    public class UserType : ObjectType<ResultUserPrivateDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserPrivateDto> descriptor)
        {
            descriptor.Name("ResultUser");
        }
    }
}
