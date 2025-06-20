namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Mutations.Inputs
{
    public record UpdateReactionOwnInput(
        string ReactionId,
        string? Payload,
        string? MessageId
    );
}
