using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Mutations.Inputs
{
    public record UpdateRecentChatsAdminInput(
        string RecentChatsId,
        string? LastMessage,
        string? UserId,
        [property: DateField] string? LastMessageAt
    );
}
