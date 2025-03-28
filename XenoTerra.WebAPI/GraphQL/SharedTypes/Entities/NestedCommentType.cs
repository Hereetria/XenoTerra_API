using XenoTerra.DTOLayer.Dtos.CommentDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedCommentType : ObjectType<ResultCommentDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultCommentDto> descriptor)
        {
            descriptor.Field(f => f.CommentId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.Content)
                .Type<StringType>();

            descriptor.Field(f => f.PostId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.UserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.CommentedAt)
                .Type<NonNullType<DateTimeType>>();
        }
    }
}
