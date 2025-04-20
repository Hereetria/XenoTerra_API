using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Mutations.Inputs
{
    public record CreateMessageInput(
        string Content,
        string SenderId,
        string ReceiverId,
        string? Header,
        [property: DateField] string SentAt
    );
}
