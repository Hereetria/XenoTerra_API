﻿using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Mutations.Inputs
{
    public record CreateStoryOwnInput(
        string Path,
        bool IsVideo
    );
}
