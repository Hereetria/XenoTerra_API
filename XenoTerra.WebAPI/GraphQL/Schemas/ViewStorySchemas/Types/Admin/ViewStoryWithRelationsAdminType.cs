using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Types.Admin
{
    public class ViewStoryWithRelationsAdminType : ObjectType<ResultViewStoryWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultViewStoryWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultViewStoryWithRelationsAdmin");
        }
    }
}
