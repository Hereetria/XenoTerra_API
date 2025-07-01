using XenoTerra.DTOLayer.Dtos.AppRoleDtos.Admin;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Types.Admin
{
    public class RoleAdminType : ObjectType<ResultAppRoleAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultAppRoleAdminDto> descriptor)
        {
            descriptor.Name("ResultAppRoleAdmin");
        }
    }
}
