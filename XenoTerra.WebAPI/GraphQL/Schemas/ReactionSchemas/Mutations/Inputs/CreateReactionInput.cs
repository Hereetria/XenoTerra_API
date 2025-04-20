namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Mutations.Inputs
{
    public record CreateReactionInput(
        string Payload,
        string MessageId,
        string UserId
    );
}
