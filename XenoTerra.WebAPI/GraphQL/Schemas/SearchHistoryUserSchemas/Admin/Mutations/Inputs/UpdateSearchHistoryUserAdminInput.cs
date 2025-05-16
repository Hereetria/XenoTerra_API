namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Mutations.Inputs
{
    public record UpdateSearchHistoryUserAdminInput(
        string SearchHistoryId,
        string UserId
    );
}
