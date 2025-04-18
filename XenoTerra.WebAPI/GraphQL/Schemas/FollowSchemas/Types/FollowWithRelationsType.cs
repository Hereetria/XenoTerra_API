using XenoTerra.DTOLayer.Dtos.FollowDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Types
{
    public class FollowWithRelationsType : ObjectType<ResultFollowWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultFollowWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultFollowWithRelations");
        }
    }
}
