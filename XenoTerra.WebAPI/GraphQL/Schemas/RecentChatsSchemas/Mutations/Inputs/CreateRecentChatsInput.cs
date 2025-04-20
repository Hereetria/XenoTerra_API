using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Mutations.Inputs
{
    public record CreateRecentChatsInput(
        string LastMessage,
        string UserId,
        [property: DateField] string LastMessageAt
    );
}
