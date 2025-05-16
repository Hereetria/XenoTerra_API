namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Mutations.Inputs
{
    public record CreateStoryHighlightAdminInput(
        string StoryId,
        string HighlightId
    );
}
