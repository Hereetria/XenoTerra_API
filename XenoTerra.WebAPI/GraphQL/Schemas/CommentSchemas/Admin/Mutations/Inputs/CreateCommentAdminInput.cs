﻿using XenoTerra.WebAPI.GraphQL.Attributes;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Inputs
{
    public record CreateCommentAdminInput(
        string Content,
        string PostId,
        string UserId,
        string? ParentCommentId
    );
}
