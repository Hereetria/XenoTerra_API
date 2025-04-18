using XenoTerra.DTOLayer.Dtos.RoleDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Types
{
    public class RoleWithRelationsType : ObjectType<ResultRoleWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultRoleWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultRoleWithRelations");
        }
    }
}
