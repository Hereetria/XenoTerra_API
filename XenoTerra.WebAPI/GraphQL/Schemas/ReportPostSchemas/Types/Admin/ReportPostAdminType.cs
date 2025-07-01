using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Types.Admin
{
    public class ReportPostAdminType : ObjectType<ResultReportPostAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReportPostAdminDto> descriptor)
        {
            descriptor.Name("ResultReportPostAdmin");
        }
    }
}
