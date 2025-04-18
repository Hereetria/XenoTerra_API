using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Types
{
    public class StoryHighlightWithRelationsType : ObjectType<ResultStoryHighlightWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryHighlightWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultStoryHighlightWithRelations");
        }
    }
}
