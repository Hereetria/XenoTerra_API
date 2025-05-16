namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Mutations.Inputs
{
    public record UpdateStoryHighlightSelfInput(
        string StoryId,
        string HighlightId
    );
}
