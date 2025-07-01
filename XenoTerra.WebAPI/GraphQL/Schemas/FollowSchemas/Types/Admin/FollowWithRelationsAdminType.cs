using XenoTerra.DTOLayer.Dtos.FollowDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Types.Admin
{
    public class FollowWithRelationsAdminType : ObjectType<ResultFollowWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultFollowWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultFollowWithRelationsAdmin");
        }
    }
}
