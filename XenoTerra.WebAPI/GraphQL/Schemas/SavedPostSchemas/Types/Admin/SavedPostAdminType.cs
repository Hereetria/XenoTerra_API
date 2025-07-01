using XenoTerra.DTOLayer.Dtos.SavedPostDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Types.Admin
{
    public class SavedPostAdminType : ObjectType<ResultSavedPostAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultSavedPostAdminDto> descriptor)
        {
            descriptor.Name("ResultSavedPostAdmin");
        }
    }
}
