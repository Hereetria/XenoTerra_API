using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Mutations.Inputs
{
    public record UpdateSearchHistoryInput(
        string SearchHistoryId,
        string? UserId
    );
}
