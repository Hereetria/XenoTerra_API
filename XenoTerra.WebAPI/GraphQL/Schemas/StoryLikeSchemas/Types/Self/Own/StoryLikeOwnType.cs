using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Types.Self.Own
{
    public class StoryLikeOwnType : ObjectType<ResultStoryLikeOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryLikeOwnDto> descriptor)
        {
            descriptor.Name("ResultStoryLikeOwn");
        }
    }
}
