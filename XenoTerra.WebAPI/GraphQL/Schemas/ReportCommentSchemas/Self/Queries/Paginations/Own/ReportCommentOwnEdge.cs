using XenoTerra.DTOLayer.Dtos.ReportCommentAdminDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Queries.Paginations.Own
{
    public class ReportCommentOwnEdge
    {
        public ResultReportCommentWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
