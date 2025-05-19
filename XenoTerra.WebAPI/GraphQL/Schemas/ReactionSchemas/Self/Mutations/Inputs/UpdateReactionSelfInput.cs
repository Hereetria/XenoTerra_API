namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Mutations.Inputs
{
    public record UpdateReactionSelfInput(
        string ReactionId,
        string? Payload,
        string? MessageId
    );
}
