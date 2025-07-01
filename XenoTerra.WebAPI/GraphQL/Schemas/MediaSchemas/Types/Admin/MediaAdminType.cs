using XenoTerra.DTOLayer.Dtos.MediaDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Types.Admin
{
    public class MediaAdminType : ObjectType<ResultMediaAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultMediaAdminDto> descriptor)
        {
            descriptor.Name("ResultMediaAdmin");
        }
    }
}
