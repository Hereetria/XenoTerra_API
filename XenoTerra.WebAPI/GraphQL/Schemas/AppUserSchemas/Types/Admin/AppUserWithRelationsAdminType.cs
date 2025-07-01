using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Types.Admin
{
    public class AppUserWithRelationsAdminType : ObjectType<ResultAppUserWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultAppUserWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultAppUserWithRelationsAdmin");
        }
    }
}
