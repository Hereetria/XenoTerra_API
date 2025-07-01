using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Types.Self.Own
{
    public class ReportPostOwnType : ObjectType<ResultReportPostOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReportPostOwnDto> descriptor)
        {
            descriptor.Name("ResultReportPostOwn");
        }
    }
}
