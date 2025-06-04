using XenoTerra.DTOLayer.Dtos.ReportPostDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Queries.Paginations
{
    public class ReportPostAdminEdge
    {
        public ResultReportPostWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
