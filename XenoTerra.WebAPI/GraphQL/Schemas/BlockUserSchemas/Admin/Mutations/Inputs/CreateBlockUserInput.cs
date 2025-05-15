using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations.Inputs
{
    public record CreateBlockUserInput(
        string BlockingUserId,
        string BlockedUserId
    );
}
