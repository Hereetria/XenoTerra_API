using XenoTerra.DTOLayer.Dtos.FollowDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Types
{
    public class FollowType : ObjectType<ResultFollowDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultFollowDto> descriptor)
        {
            descriptor.Name("ResultFollow");
        }
    }
}
