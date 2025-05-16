namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Mutations.Inputs
{
    public record CreateReactionAdminInput(
        string Payload,
        string MessageId,
        string UserId
    );
}
