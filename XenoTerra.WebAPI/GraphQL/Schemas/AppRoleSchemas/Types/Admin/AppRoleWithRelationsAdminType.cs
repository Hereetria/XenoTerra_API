using XenoTerra.DTOLayer.Dtos.AppRoleDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Types.Admin
{
    public class RoleWithRelationsAdminType : ObjectType<ResultAppRoleWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultAppRoleWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultAppRoleWithRelationsAdmin");
        }
    }
}
