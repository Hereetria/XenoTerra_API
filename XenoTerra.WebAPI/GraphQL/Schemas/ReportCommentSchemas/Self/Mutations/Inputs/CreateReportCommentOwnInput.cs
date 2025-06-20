using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Mutations.Inputs
{
    public record CreateReportCommentOwnInput(
        string ReporterUserId,
        string CommentId,
        string Reason
    );
}
