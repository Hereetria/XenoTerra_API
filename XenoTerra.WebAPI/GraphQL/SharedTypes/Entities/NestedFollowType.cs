using XenoTerra.DTOLayer.Dtos.FollowDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedFollowType : ObjectType<ResultFollowDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultFollowDto> descriptor)
        {
            descriptor.Field(f => f.FollowId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.FollowerId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.FollowingId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.FollowedAt)
                .Type<NonNullType<DateTimeType>>();
        }
    }
}
