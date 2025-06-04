using XenoTerra.DTOLayer.Dtos.AppRoleDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Types
{
    public class RoleWithRelationsType : ObjectType<ResultAppRoleWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultAppRoleWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultAppRoleWithRelations");
        }
    }
}
