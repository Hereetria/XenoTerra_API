using XenoTerra.DTOLayer.Dtos.HighlightDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Types.Admin
{
    public class HighlightWithRelationsAdminType : ObjectType<ResultHighlightWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultHighlightWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultHighlightWithRelationsAdmin");
        }
    }
}
