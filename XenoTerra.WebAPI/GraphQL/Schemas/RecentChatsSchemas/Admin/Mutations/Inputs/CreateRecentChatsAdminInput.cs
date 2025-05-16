using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Mutations.Inputs
{
    public record CreateRecentChatsAdminInput(
        string LastMessage,
        string UserId
    );
}
