using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Types.Self.Own
{
    public class ReportPostWithRelationsOwnType : ObjectType<ResultReportPostWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultReportPostWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultReportPostWithRelationsOwn");
        }
    }
}
