namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Mutations.Inputs
{
    public record UpdateReactionSelfInput(
        string ReactionId,
        string? Payload,
        string? MessageId,
        string? UserId
    );
}
