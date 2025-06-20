using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Mutations.Inputs
{
    public record CreateMessageOwnInput(
        string Content,
        string ReceiverId,
        string? Header
    );
}
