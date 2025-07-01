using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Types.Self.Own
{
    public class ReportStoryOwnType : ObjectType<ResultReportStoryOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReportStoryOwnDto> descriptor)
        {
            descriptor.Name("ResultReportStoryOwn");
        }
    }
}
