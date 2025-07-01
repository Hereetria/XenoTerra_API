using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Mutations.Inputs
{
    public record UpdateUserPostTagOwnInput(
        string UserPostTagId,
        string? Content,
        string? PostId,
        string? ParentUserPostTagId
    );
}
