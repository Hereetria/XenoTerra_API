using XenoTerra.DTOLayer.Dtos.StoryLikeDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Types
{
    public class StoryLikeType : ObjectType<ResultStoryLikeDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryLikeDto> descriptor)
        {
            descriptor.Name("ResultStoryLike");
        }
    }
}
