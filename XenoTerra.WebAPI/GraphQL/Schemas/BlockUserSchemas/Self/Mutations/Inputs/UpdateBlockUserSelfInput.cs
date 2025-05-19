using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Mutations.Inputs
{
    public record UpdateBlockUserSelfInput(
        string BlockUserId,
        string? BlockedUserId
    );
}
