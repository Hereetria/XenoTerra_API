using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Mutations.Inputs
{
    public record UpdateReportCommentInput(
        string ReportCommentId,
        string? ReporterUserId,
        string? CommentId,
        string? Reason
    );
}
