using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Mutations.Inputs
{
    public record UpdateMessageOwnInput(
        string MessageId,
        string? Content,
        string? ReceiverId,
        string? Header
    );
}
