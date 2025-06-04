using XenoTerra.DTOLayer.Dtos.AppRoleDtos;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Types
{
    public class RoleType : ObjectType<ResultAppRoleDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultAppRoleDto> descriptor)
        {
            descriptor.Name("ResultAppRole");
        }
    }
}
