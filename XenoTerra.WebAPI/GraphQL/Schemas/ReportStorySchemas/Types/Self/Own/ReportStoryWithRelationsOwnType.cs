using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Types.Self.Own
{
    public class ReportStoryWithRelationsOwnType : ObjectType<ResultReportStoryWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReportStoryWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultReportStoryWithRelationsOwn");
        }
    }
}
