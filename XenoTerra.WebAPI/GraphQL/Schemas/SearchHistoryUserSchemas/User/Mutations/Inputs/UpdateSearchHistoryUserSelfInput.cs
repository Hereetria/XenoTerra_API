namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Mutations.Inputs
{
    public record UpdateSearchHistoryUserSelfInput(
        string SearchHistoryId,
        string UserId
    );
}
