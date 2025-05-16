using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations.Inputs
{
    public record UpdateBlockUserAdminInput(
        string BlockUserId,
        string? BlockingUserId,
        string? BlockedUserId
    );
}
