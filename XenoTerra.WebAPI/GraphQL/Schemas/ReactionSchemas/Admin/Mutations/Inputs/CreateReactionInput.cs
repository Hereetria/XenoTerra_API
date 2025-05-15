namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Mutations.Inputs
{
    public record CreateReactionInput(
        string Payload,
        string MessageId,
        string UserId
    );
}
