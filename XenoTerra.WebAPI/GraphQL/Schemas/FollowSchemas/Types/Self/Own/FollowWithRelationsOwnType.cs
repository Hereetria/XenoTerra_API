using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Types.Self.Own
{
    public class FollowWithRelationsOwnType : ObjectType<ResultFollowWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultFollowWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultFollowWithRelationsOwn");
        }
    }
}
