using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Mutations.Inputs
{
    public record UpdateRecentChatsInput(
        string RecentChatsId,
        string? LastMessage,
        string? UserId,
        [property: DateField] string? LastMessageAt
    );
}
