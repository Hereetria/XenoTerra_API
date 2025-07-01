using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Types.Admin
{
    public class StoryHighlightAdminType : ObjectType<ResultStoryHighlightAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryHighlightAdminDto> descriptor)
        {
            descriptor.Name("ResultStoryHighlightAdmin");
        }
    }
}
