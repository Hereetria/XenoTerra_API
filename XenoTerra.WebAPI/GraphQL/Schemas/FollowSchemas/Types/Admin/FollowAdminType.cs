using XenoTerra.DTOLayer.Dtos.FollowDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Types.Admin
{
    public class FollowAdminType : ObjectType<ResultFollowAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultFollowAdminDto> descriptor)
        {
            descriptor.Name("ResultFollowAdmin");
        }
    }
}
