using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Mutations.Inputs
{
    public record UpdateReportCommentOwnInput(
        string ReportCommentId,
        string? CommentId
    );
}
