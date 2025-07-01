using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Types.Self.Public
{
    public class FollowWithRelationsPublicType : ObjectType<ResultFollowWithRelationsPublicDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultFollowWithRelationsPublicDto> descriptor)
        {
            descriptor.Name("ResultFollowWithRelationsPublic");
        }
    }
}
