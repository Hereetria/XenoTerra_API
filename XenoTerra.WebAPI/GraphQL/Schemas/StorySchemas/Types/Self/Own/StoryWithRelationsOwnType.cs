using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Types.Self.Own
{
    public class StoryWithRelationsOwnType : ObjectType<ResultStoryWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultStoryWithRelationsOwn");
        }
    }
}
