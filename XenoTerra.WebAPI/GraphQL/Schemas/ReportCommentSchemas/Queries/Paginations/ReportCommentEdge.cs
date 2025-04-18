using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Queries.Paginations
{
    public class ReportCommentEdge
    {
        public ResultReportCommentWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
