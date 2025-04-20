namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Mutations.Inputs
{
    public record CreateStoryHighlightInput(
        string StoryId,
        string HighlightId
    );
}
