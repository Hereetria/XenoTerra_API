using XenoTerra.DTOLayer.Dtos.StoryDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Types.Admin
{
    public class StoryWithRelationsAdminType : ObjectType<ResultStoryWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultStoryWithRelationsAdmin");
        }
    }
}
