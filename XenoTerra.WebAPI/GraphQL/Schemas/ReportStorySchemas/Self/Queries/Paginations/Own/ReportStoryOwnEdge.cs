using XenoTerra.DTOLayer.Dtos.ReportStoryAdminDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Queries.Paginations.Own
{
    public class ReportStoryOwnEdge
    {
        public ResultReportStoryWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
