namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Mutations.Inputs
{
    public record CreateReactionSelfInput(
        string Payload,
        string MessageId,
        string UserId
    );
}
