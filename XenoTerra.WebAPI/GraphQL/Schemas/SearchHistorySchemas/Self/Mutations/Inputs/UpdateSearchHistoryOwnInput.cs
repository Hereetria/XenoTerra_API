using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Mutations.Inputs
{
    public record UpdateSearchHistoryOwnInput(
        string SearchHistoryId,
        string? UserId
    );
}
