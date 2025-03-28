using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedStoryType : ObjectType<ResultStoryDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryDto> descriptor)
        {
            descriptor.Field(f => f.StoryId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.Path)
                .Type<StringType>();

            descriptor.Field(f => f.IsVideo)
                .Type<NonNullType<BooleanType>>();

            descriptor.Field(f => f.UserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.CreatedAt)
                .Type<NonNullType<DateTimeType>>();
        }
    }
}
