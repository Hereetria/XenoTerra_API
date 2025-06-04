using XenoTerra.DTOLayer.Dtos.AppUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Types
{
    public class UserType : ObjectType<ResultAppUserPrivateDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultAppUserPrivateDto> descriptor)
        {
            descriptor.Name("ResultAppUser");
        }
    }
}
