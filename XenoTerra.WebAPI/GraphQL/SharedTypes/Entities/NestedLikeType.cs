using XenoTerra.DTOLayer.Dtos.LikeDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedLikeType : ObjectType<ResultLikeDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultLikeDto> descriptor)
        {
            descriptor.Field(f => f.LikeId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.PostId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.UserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.LikedAt)
                .Type<NonNullType<DateTimeType>>();
        }
    }
}
