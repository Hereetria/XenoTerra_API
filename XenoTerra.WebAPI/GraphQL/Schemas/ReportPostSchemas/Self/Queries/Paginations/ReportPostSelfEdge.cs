using XenoTerra.DTOLayer.Dtos.ReportPostDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Queries.Paginations
{
    public class ReportPostSelfEdge
    {
        public ResultReportPostWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
