using XenoTerra.DTOLayer.Dtos.HighlightDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Types.Admin
{
    public class HighlightAdminType : ObjectType<ResultHighlightAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultHighlightAdminDto> descriptor)
        {
            descriptor.Name("ResultHighlightAdmin");
        }
    }
}
