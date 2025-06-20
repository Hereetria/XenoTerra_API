using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Mutations.Inputs
{
    public record CreateRecentChatsOwnInput(
        string LastMessage
    );
}
