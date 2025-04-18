using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Types
{
    public class ViewStoryType : ObjectType<ResultViewStoryDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultViewStoryDto> descriptor)
        {
            descriptor.Name("ResultViewStory");
        }
    }
}
