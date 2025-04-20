namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Mutations.Inputs
{
    public record CreateSearchHistoryUserInput(
        string SearchHistoryId,
        string UserId
    );
}
