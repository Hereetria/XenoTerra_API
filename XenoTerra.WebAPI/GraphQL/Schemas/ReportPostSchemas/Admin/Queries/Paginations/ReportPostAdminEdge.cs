using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Queries.Paginations
{
    public class ReportPostAdminEdge
    {
        public ResultReportPostWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
