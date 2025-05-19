using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Mutations.Inputs
{
    public record CreateMessageSelfInput(
        string Content,
        string ReceiverId,
        string? Header
    );
}
