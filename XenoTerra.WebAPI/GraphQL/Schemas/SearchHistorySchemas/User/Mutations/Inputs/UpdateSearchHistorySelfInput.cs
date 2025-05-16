using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Mutations.Inputs
{
    public record UpdateSearchHistorySelfInput(
        string SearchHistoryId,
        string? UserId
    );
}
