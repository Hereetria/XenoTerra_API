using XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Types.Admin
{
    public class ReportCommentWithRelationsAdminType : ObjectType<ResultReportCommentWithRelationsAdminDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReportCommentWithRelationsAdminDto> descriptor)
        {
            descriptor.Name("ResultReportCommentWithRelationsAdmin");
        }
    }
}
