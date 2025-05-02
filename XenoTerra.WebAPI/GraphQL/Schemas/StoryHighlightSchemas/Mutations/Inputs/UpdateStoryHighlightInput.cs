namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Mutations.Inputs
{
    public record UpdateStoryHighlightInput(
        string StoryId,
        string HighlightId
    );
}
