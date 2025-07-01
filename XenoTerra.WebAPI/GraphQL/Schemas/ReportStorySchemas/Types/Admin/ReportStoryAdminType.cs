using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Types.Admin
{
    public class ReportStoryAdminType : ObjectType<ResultReportStoryAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReportStoryAdminDto> descriptor)
        {
            descriptor.Name("ResultReportStoryAdmin");
        }
    }
}
