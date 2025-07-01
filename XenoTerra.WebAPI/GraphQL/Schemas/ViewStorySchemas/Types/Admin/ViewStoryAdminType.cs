using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Types.Admin
{
    public class ViewStoryAdminType : ObjectType<ResultViewStoryAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultViewStoryAdminDto> descriptor)
        {
            descriptor.Name("ResultViewStoryAdmin");
        }
    }
}
