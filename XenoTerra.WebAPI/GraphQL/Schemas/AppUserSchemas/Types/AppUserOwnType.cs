using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Types
{
    public class AppUserOwnType : ObjectType<ResultAppUserOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultAppUserOwnDto> descriptor)
        {
            descriptor.Name("ResultAppUserOwn");
        }
    }
}
