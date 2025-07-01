using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Types.Self.Public
{
    public class StoryWithRelationsPublicType : ObjectType<ResultStoryWithRelationsPublicDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryWithRelationsPublicDto> descriptor)
        {
            descriptor.Name("ResultStoryWithRelationsPublic");
        }
    }
}
