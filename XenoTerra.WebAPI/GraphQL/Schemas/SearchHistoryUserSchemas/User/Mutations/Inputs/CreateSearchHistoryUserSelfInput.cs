namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Mutations.Inputs
{
    public record CreateSearchHistoryUserSelfInput(
        string SearchHistoryId,
        string UserId
    );
}
