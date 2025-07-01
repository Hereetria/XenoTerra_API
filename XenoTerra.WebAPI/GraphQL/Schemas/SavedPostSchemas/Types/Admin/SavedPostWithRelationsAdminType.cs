using XenoTerra.DTOLayer.Dtos.SavedPostDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Types.Admin
{
    public class SavedPostWithRelationsAdminType : ObjectType<ResultSavedPostWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultSavedPostWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultSavedPostWithRelationsAdmin");
        }
    }
}
