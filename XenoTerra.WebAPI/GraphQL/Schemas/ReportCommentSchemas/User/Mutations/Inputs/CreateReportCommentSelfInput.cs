using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Mutations.Inputs
{
    public record CreateReportCommentSelfInput(
        string ReporterUserId,
        string CommentId,
        string Reason
    );
}
