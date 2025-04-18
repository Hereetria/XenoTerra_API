using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Types
{
    public class StoryWithRelationsType : ObjectType<ResultStoryWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultStoryWithRelations");
        }
    }
}
