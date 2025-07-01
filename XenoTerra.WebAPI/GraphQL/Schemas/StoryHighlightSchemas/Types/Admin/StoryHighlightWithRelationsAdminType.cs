using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Types.Admin
{
    public class StoryHighlightWithRelationsAdminType : ObjectType<ResultStoryHighlightWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryHighlightWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultStoryHighlightWithRelationsAdmin");
        }
    }
}
