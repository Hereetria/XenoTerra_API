using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Types
{
    public class AppUserWithRelationsPublicType : ObjectType<ResultAppUserWithRelationsPublicDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultAppUserWithRelationsPublicDto> descriptor)
        {
            descriptor.Name("ResultAppUserWithRelationsPublic");
        }
    }
}
