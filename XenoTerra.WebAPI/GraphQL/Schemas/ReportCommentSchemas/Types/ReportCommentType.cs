using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Types
{
    public class ReportCommentType : ObjectType<ResultReportCommentDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReportCommentDto> descriptor)
        {
            descriptor.Name("ResultReportComment");
        }
    }
}
