using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Types.Admin
{
    public class StoryLikeWithRelationsAdminType : ObjectType<ResultStoryLikeWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryLikeWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultStoryLikeWithRelationsAdmin");
        }
    }
}
