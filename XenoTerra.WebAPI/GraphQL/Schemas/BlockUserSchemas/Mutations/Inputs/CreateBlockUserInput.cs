using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Models
{
    public record CreateBlockUserInput(
        string BlockingUserId,
        string BlockedUserId
    );
}
