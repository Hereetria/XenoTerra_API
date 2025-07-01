using XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries.Paginations
{
    public class ReportCommentAdminEdge
    {
        public ResultReportCommentWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
