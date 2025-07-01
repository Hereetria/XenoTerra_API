using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Types.Admin
{
    public class UserPostTagWithRelationsAdminType : ObjectType<ResultUserPostTagWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserPostTagWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultUserPostTagWithRelationsAdmin");
        }
    }
}
