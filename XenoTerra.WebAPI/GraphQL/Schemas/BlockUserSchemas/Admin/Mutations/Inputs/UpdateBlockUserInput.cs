using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations.Inputs
{
    public record UpdateBlockUserInput(
        string BlockUserId,
        string? BlockingUserId,
        string? BlockedUserId
    );
}
