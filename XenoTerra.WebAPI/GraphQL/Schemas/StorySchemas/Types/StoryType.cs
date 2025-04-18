using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Types
{
    public class StoryType : ObjectType<ResultStoryDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryDto> descriptor)
        {
            descriptor.Name("ResultStory");
        }
    }
}
