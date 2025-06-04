using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Mutations.Inputs
{
    public record UpdateReportPostAdminInput(
        string ReportPostId,
        string? ReporterUserId,
        string? CommentId,
        string? Reason
    );
}
