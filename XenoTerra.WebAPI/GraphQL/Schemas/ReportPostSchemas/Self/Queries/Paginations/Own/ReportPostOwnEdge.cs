using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Queries.Paginations.Own
{
    public class ReportPostOwnEdge
    {
        public ResultReportPostWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
