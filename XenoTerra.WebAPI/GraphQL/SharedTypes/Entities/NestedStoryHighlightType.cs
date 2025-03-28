using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedStoryHighlightType : ObjectType<ResultStoryHighlightDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryHighlightDto> descriptor)
        {
            descriptor.Field(f => f.StoryId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.HighlightId)
                .Type<NonNullType<IdType>>();
        }
    }
}
