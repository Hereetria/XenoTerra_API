namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Mutations.Inputs
{
    public record CreateReactionSelfInput(
        string Payload,
        string MessageId
    );
}
