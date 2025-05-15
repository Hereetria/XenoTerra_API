namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Mutations.Inputs
{
    public record CreateStoryHighlightInput(
        string StoryId,
        string HighlightId
    );
}
