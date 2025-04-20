using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.DTOLayer.Dtos.RoleDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Types
{
    public class RoleType : ObjectType<ResultRoleDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultRoleDto> descriptor)
        {
            descriptor.Name("ResultRole");
        }
    }
}
