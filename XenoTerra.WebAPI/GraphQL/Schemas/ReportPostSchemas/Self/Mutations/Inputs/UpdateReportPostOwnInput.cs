using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Mutations.Inputs
{
    public record UpdateReportPostOwnInput(
        string ReportPostId,
        string? PostId
    );
}
