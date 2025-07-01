using XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Types.Admin
{
    public class ReportCommentAdminType : ObjectType<ResultReportCommentAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReportCommentAdminDto> descriptor)
        {
            descriptor.Name("ResultReportCommentAdmin");
        }
    }
}
