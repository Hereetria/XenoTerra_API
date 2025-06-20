using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Mutations.Inputs
{
    public record UpdateBlockUserOwnInput(
        string BlockUserId,
        string? BlockedUserId
    );
}
