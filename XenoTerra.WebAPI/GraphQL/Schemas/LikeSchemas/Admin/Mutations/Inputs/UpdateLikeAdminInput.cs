﻿using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Mutations.Inputs
{
    public record UpdateLikeAdminInput(
        string LikeId,
        string? PostId,
        string? UserId
    );
}
