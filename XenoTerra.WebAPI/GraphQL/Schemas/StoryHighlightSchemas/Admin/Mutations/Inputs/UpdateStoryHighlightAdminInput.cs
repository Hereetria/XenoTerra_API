namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Mutations.Inputs
{
    public record UpdateStoryHighlightAdminInput(
        string StoryId,
        string HighlightId
    );
}
