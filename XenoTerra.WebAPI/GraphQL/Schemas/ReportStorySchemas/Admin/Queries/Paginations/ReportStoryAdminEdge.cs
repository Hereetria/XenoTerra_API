using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Queries.Paginations
{
    public class ReportStoryAdminEdge
    {
        public ResultReportStoryWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
