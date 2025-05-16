namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Mutations.Inputs
{
    public record CreateSearchHistoryUserAdminInput(
        string SearchHistoryId,
        string UserId
    );
}
