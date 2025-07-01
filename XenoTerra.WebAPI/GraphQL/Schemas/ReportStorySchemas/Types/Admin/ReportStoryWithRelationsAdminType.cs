using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Types.Admin
{
    public class ReportStoryWithRelationsAdminType : ObjectType<ResultReportStoryWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReportStoryWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultReportStoryWithRelationsAdmin");
        }
    }
}
