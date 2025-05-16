using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Inputs
{
    public record CreateMessageSelfInput(
        string Content,
        string SenderId,
        string ReceiverId,
        string? Header
    );
}
