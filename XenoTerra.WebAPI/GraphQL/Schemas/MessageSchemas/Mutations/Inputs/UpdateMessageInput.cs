using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Mutations.Inputs
{
    public record UpdateMessageInput(
        string MessageId,
        string? Content,
        string? SenderId,
        string? ReceiverId,
        string? Header
    );
}
