namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Mutations.Inputs
{
    public record UpdateStoryHighlightInput(
        string StoryId,
        string HighlightId
    );
}
