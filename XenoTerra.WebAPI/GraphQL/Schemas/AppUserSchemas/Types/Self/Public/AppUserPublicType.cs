using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Types.Self.Public
{
    public class AppUserPublicType : ObjectType<ResultAppUserPublicDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultAppUserPublicDto> descriptor)
        {
            descriptor.Name("ResultAppUserPublic");
        }
    }
}
