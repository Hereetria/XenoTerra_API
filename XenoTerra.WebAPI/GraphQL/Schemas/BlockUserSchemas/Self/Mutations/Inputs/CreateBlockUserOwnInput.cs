﻿using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Mutations.Inputs
{
    public record CreateBlockUserOwnInput(
        string BlockedUserId
    );
}
