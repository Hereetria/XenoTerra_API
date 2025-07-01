using XenoTerra.DTOLayer.Dtos.MediaDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Types.Admin
{
    public class MediaWithRelationsAdminType : ObjectType<ResultMediaWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultMediaWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultMediaWithRelationsAdmin");
        }
    }
}
