using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Types.Admin
{
    public class StoryLikeAdminType : ObjectType<ResultStoryLikeAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultStoryLikeAdminDto> descriptor)
        {
            descriptor.Name("ResultStoryLikeAdmin");
        }
    }
}
