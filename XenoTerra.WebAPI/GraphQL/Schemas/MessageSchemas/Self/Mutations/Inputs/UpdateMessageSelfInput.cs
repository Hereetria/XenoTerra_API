using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Mutations.Inputs
{
    public record UpdateMessageSelfInput(
        string MessageId,
        string? Content,
        string? ReceiverId,
        string? Header
    );
}
