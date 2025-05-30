﻿namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Mutations.Inputs
{
    public record UpdateReactionAdminInput(
        string ReactionId,
        string? Payload,
        string? MessageId,
        string? UserId
    );
}
