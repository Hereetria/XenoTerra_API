using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Types.Self.Own
{
    public class StoryHighlightWithRelationsOwnType : ObjectType<ResultStoryHighlightWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryHighlightWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultStoryHighlightWithRelationsOwn");
        }
    }
}
