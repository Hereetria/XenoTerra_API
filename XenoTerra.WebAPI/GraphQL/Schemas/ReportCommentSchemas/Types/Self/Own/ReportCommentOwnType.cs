using XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Types.Self.Own
{
    public class ReportCommentOwnType : ObjectType<ResultReportCommentOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReportCommentOwnDto> descriptor)
        {
            descriptor.Name("ResultReportCommentOwn");
        }
    }
}
