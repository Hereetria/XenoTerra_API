using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedViewStoryType : ObjectType<ResultViewStoryDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultViewStoryDto> descriptor)
        {
            descriptor.Field(f => f.ViewStoryId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.StoryId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.UserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.ViewedAt)
                .Type<NonNullType<DateTimeType>>();
        }
    }
}
