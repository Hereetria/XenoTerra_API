using XenoTerra.DTOLayer.Dtos.ReportPostDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Types
{
    public class ReportPostType : ObjectType<ResultReportPostDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReportPostDto> descriptor)
        {
            descriptor.Name("ResultReportPost");
        }
    }
}
