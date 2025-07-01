using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Types.Self.Own
{
    public class FollowOwnType : ObjectType<ResultFollowOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultFollowOwnDto> descriptor)
        {
            descriptor.Name("ResultFollowOwn");
        }
    }
}
