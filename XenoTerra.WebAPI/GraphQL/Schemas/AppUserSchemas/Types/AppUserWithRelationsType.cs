using XenoTerra.DTOLayer.Dtos.AppUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Types
{
    public class AppUserWithRelationsType : ObjectType<ResultAppUserWithRelationsPrivateDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultAppUserWithRelationsPrivateDto> descriptor)
        {
            descriptor.Name("ResultAppUserWithRelations");
        }
    }
}
