using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Mutations.Inputs
{
    public record UpdateReportPostSelfInput(
        string ReportPostId,
        string? ReporterUserId,
        string? CommentId,
        string? Reason
    );
}
