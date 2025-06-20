using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Types
{
    public class AppUserWithRelationsOwnType : ObjectType<ResultAppUserWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultAppUserWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultAppUserWithRelationsOwn");
        }
    }
}
