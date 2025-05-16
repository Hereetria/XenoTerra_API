using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations.Inputs
{
    public record CreateBlockUserAdminInput(
        string BlockingUserId,
        string BlockedUserId
    );
}
