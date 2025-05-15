namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Mutations.Inputs
{
    public record UpdateSearchHistoryUserInput(
        string SearchHistoryId,
        string UserId
    );
}
