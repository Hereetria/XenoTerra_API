using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Mutations.Inputs
{
    public record CreateReportCommentInput(
        string ReporterUserId,
        string CommentId,
        string Reason
    );
}
