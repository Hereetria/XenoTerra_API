using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Types.Admin
{
    public class ReportPostWithRelationsAdminType : ObjectType<ResultReportPostWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReportPostWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultReportPostWithRelationsAdmin");
        }
    }
}
