using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Mutations.Inputs
{
    public record CreateReportStoryAdminInput(
        string StoryId,
        string ReporterUserId
    );
}
