using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Types
{
    public class StoryHighlightType : ObjectType<ResultStoryHighlightDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryHighlightDto> descriptor)
        {
            descriptor.Name("ResultStoryHighlight");
        }
    }
}
