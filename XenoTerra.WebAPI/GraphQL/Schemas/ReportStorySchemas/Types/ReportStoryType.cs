using XenoTerra.DTOLayer.Dtos.ReportStoryDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Types
{
    public class ReportStoryType : ObjectType<ResultReportStoryDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReportStoryDto> descriptor)
        {
            descriptor.Name("ResultReportStory");
        }
    }
}
