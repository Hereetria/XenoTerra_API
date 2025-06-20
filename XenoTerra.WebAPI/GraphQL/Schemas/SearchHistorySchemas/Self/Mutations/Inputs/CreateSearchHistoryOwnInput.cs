using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Mutations.Inputs
{
    public record CreateSearchHistoryOwnInput(
        string UserId
    );
}
