using XenoTerra.DTOLayer.Dtos.ReportStoryDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Types
{
    public class ReportStoryWithRelationsType : ObjectType<ResultReportStoryWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReportStoryWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultReportStoryWithRelations");
        }
    }
}
