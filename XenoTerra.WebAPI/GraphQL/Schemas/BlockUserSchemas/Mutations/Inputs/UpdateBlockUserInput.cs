﻿using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Inputs
{
    public record UpdateBlockUserInput(
        string BlockUserId,
        string? BlockingUserId,
        string? BlockedUserId
    );
}
