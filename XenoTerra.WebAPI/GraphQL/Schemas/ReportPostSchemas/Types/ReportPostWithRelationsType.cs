using XenoTerra.DTOLayer.Dtos.ReportPostDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Types
{
    public class ReportPostWithRelationsType : ObjectType<ResultReportPostWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReportPostWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultReportPostWithRelations");
        }
    }
}
