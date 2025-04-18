using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Types
{
    public class ReportCommentWithRelationsType : ObjectType<ResultReportCommentWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReportCommentWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultReportCommentWithRelations");
        }
    }
}
