﻿using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations.Inputs
{
    public record CreateStoryAdminInput(
        string Path,
        bool IsVideo,
        string UserId
    );
}
