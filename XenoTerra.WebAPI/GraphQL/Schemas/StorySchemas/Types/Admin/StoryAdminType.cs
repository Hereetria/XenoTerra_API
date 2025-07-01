using XenoTerra.DTOLayer.Dtos.StoryDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Types.Admin
{
    public class StoryAdminType : ObjectType<ResultStoryAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryAdminDto> descriptor)
        {
            descriptor.Name("ResultStoryAdmin");
        }
    }
}
