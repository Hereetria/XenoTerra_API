namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Mutations.Inputs
{
    public record CreateSearchHistoryUserInput(
        string SearchHistoryId,
        string UserId
    );
}
