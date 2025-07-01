using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Types.Self.Own
{
    public class StoryLikeWithRelationsOwnType : ObjectType<ResultStoryLikeWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryLikeWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultStoryLikeWithRelationsOwn");
        }
    }
}
