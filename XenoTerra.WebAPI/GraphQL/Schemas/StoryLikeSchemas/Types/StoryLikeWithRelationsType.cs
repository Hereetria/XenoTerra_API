using XenoTerra.DTOLayer.Dtos.StoryLikeDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Types
{
    public class StoryLikeWithRelationsType : ObjectType<ResultStoryLikeWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryLikeWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultStoryLikeWithRelations");
        }
    }
}
