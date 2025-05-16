namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Mutations.Inputs
{
    public record CreateStoryHighlightSelfInput(
        string StoryId,
        string HighlightId
    );
}
