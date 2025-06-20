using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Mutations.Inputs
{
    public record UpdateReportStoryAdminInput(
        string ReportStoryId,
        string? StoryId,
        string? ReporterUserId
    );
}
