using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Types.Admin
{
    public class AppUserAdminType : ObjectType<ResultAppUserAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultAppUserAdminDto> descriptor)
        {
            descriptor.Name("ResultAppUserAdmin");
        }
    }
}
