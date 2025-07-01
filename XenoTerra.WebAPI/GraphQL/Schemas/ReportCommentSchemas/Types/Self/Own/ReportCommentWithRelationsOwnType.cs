using XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Types.Self.Own
{
    public class ReportCommentWithRelationsOwnType : ObjectType<ResultReportCommentWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReportCommentWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultReportCommentWithRelationsOwn");
        }
    }
}
