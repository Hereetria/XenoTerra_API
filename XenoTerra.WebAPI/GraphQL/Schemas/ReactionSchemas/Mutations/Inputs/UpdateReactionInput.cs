namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Mutations.Inputs
{
    public record UpdateReactionInput(
        string ReactionId,
        string? Payload,
        string? MessageId,
        string? UserId
    );
}
