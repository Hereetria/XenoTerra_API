using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Types.Self.Own
{
    public class StoryOwnType : ObjectType<ResultStoryOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryOwnDto> descriptor)
        {
            descriptor.Name("ResultStoryOwn");
        }
    }
}
