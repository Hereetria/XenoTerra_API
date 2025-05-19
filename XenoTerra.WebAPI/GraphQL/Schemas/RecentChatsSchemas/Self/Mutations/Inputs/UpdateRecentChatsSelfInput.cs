using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Mutations.Inputs
{
    public record UpdateRecentChatsSelfInput(
        string RecentChatsId,
        string? LastMessage,
        [property: DateField] string? LastMessageAt
    );
}
