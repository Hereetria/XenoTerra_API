using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Types.Self.Public
{
    public class StoryPublicType : ObjectType<ResultStoryPublicDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryPublicDto> descriptor)
        {
            descriptor.Name("ResultStoryPublic");
        }
    }
}
