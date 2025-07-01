using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Types.Self.Public
{
    public class FollowPublicType : ObjectType<ResultFollowPublicDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultFollowPublicDto> descriptor)
        {
            descriptor.Name("ResultFollowPublic");
        }
    }
}
