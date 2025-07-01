using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Types.Self.Own
{
    public class StoryHighlightOwnType : ObjectType<ResultStoryHighlightOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryHighlightOwnDto> descriptor)
        {
            descriptor.Name("ResultStoryHighlightOwn");
        }
    }
}
