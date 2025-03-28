using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class ReportCommentEdge
    {
        public ResultReportCommentWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
