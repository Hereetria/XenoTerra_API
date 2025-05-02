namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Mutations.Inputs
{
    public record UpdateSearchHistoryUserInput(
        string SearchHistoryId,
        string UserId
    );
}
