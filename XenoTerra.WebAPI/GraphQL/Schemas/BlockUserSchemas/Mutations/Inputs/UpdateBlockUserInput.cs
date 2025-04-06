using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Models
{
    public record UpdateBlockUserInput(
        string BlockUserId,
        string? BlockingUserId,
        string? BlockedUserId,
        [property: DateField] string? BlockedAt 
    );
}
