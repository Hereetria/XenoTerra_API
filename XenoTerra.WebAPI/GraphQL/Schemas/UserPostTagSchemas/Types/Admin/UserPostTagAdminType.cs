using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Types.Admin
{
    public class UserPostTagAdminType : ObjectType<ResultUserPostTagAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserPostTagAdminDto> descriptor)
        {
            descriptor.Name("ResultUserPostTagAdmin");
        }
    }
}
